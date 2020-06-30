using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using MyLocalTwitterStats.OAuth;
using Newtonsoft.Json.Linq;

namespace MyLocalTwitterStats
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		const string friendsurl = "https://api.twitter.com/1.1/friends/ids.json";
		const string friendslisturl = "https://api.twitter.com/1.1/friends/list.json";
		const string followersurl = "https://api.twitter.com/1.1/followers/ids.json";
		public List<string> newFollowers;
		public List<string> newFriends;
		public List<string> unFollow;
		public List<string> unFriend;

		private void Form1_Load(object sender, EventArgs e)
		{

			lblWait.Visible = true;
			
			grpLost.Controls.Clear();
			grpDitched.Controls.Clear();
			grpFriends.Controls.Clear();
			grpFollow.Controls.Clear();
			
			bwQueryTwit.RunWorkerAsync();
		}

		private void bwQueryTwit_DoWork(object sender, DoWorkEventArgs e)
		{
			var settings = Properties.Settings.Default;
			newFollowers = new List<string>();
			newFriends = new List<string>();
			unFollow = new List<string>();
			unFriend = new List<string>();

			System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

			var client = new HttpClient(new OAuthMessageHandler(new HttpClientHandler()));
			
			var response = client.GetAsync(friendsurl);
			while (!response.IsCompleted)
				System.Threading.Thread.Sleep(100);

			var friendbag = response.Result.Content.ReadAsAsync<JToken>();
			while (!friendbag.IsCompleted)
				System.Threading.Thread.Sleep(100);

			if (friendbag.Result.HasValues)
			{
				var tmp = friendbag.Result.First.ToString();
				tmp = tmp.Substring(tmp.IndexOf("[") + 1);
				tmp = tmp.Substring(0, tmp.IndexOf("]"));
				var allids = tmp.Split(',').Select(s => s.TrimStart('\r', '\n', ' ', '\t').TrimEnd('\r', '\n', ' ', '\t')).ToArray();
				var col = new StringCollection();
				col.AddRange(allids);
				settings.FriendsNow = col;
				settings.Save();
			}

			client = new HttpClient(new OAuthMessageHandler(new HttpClientHandler()));
			response = client.GetAsync(followersurl);
			while (!response.IsCompleted)
				System.Threading.Thread.Sleep(100);

			var followbag = response.Result.Content.ReadAsAsync<JToken>();
			while (!followbag.IsCompleted)
				System.Threading.Thread.Sleep(100);

			if (followbag.Result.HasValues)
			{
				var tmp = followbag.Result.First.ToString();
				tmp = tmp.Substring(tmp.IndexOf("[") + 1);
				tmp = tmp.Substring(0, tmp.IndexOf("]"));
				var allids = tmp.Split(',').Select(s=>s.TrimStart('\r','\n',' ','\t').TrimEnd('\r', '\n', ' ', '\t')).ToArray();

				var col = new StringCollection();
				col.AddRange(allids);
				settings.FollowersNow = col;
			}

			var followchange = false;
			var friendchange = false;
			var old = settings.FollowersLast;
			foreach (var follower in newFollowers)
			{
				if (!old.Contains(follower))
				{
					followchange = true;
					break;
				}
			}
			foreach (var follower in old)
			{
				if (!newFollowers.Contains(follower))
				{
					followchange = true;
					break;
				}
			}

			old = settings.FriendsLast;

			foreach (var follower in newFriends)
			{
				if (!old.Contains(follower))
				{
					friendchange = true;
					break;
				}
			}
			foreach (var follower in old)
			{
				if (!newFriends.Contains(follower))
				{
					friendchange = true;
					break;
				}
			}

			if (friendchange)
			{
				var listNow = settings.FriendsNow.Cast<string>().ToList();
				var listOld = settings.FriendsLast.Cast<string>().ToList();
				var added = listNow.Where(l => !listOld.Contains(l)).ToList();
				var gone = listOld.Where(l => !listNow.Contains(l)).ToList();
				newFriends.AddRange(added);
				unFriend.AddRange(gone);
			}

			if (followchange)
			{
				var listNow = settings.FollowersNow.Cast<string>().ToList();
				var listOld = settings.FollowersLast.Cast<string>().ToList();
				var added = listNow.Where(l => !listOld.Contains(l)).ToList();
				var gone = listOld.Where(l => !listNow.Contains(l)).ToList();
				newFollowers.AddRange(added);
				unFollow.AddRange(gone);
			}

		}

		private void bwQueryTwit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			lblFollowers.Text = Properties.Settings.Default.FollowersNow.Count.ToString();
			lblFriends.Text = Properties.Settings.Default.FriendsNow.Count.ToString();

			PopulateGroup(newFollowers, grpFollow);
			PopulateGroup(unFollow, grpLost);
			PopulateGroup(newFriends, grpFriends);
			PopulateGroup(unFriend, grpDitched);

			lblWait.Visible = false;
		}

		private void PopulateGroup(List<string> collPeople, GroupBox groupBox)
		{
			var folTop = new Point(12, 25);
			var ctr = 1;
			foreach (var fol in collPeople)
			{
				var kvp = LookupUser(fol);
				if (string.IsNullOrEmpty(kvp.Key)) continue;
				var linklabel = new LinkLabel()
				{
					Text = kvp.Value,
					Width = 200,
					Height = 15,
					Location = folTop,
					Name = $"follbl{ctr}"
				};
				ctr++;
				linklabel.Links.Add(0, linklabel.Width - 1, $"https://twitter.com/{kvp.Key}");
				linklabel.Click += Linklabel_Click;
				groupBox.Controls.Add(linklabel);
				folTop.Y += 25;
			}
		}

		private void Linklabel_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(((LinkLabel) sender).Links[0].LinkData.ToString());
		}

		private static KeyValuePair<string, string> LookupUser(string userid)
		{
			var client = new HttpClient(new OAuthMessageHandler(new HttpClientHandler()));

			var response = client.GetAsync($"https://api.twitter.com/1.1/users/lookup.json?user_id=" + userid);
			while (!response.IsCompleted)
				System.Threading.Thread.Sleep(100);

			var userbag = response.Result.Content.ReadAsAsync<JToken>();
			while (!userbag.IsCompleted)
				System.Threading.Thread.Sleep(100);

			try
			{
				if (userbag.Result.HasValues)
				{
					var tmp = userbag.Result.First;
					return new KeyValuePair<string, string>(tmp.Value<string>("screen_name"), tmp.Value<string>("name"));
				}
				return new KeyValuePair<string, string>(null, null);
			}
			catch
			{
				return new KeyValuePair<string, string>(null, null);
			}
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			grpLost.Controls.Clear();
			grpDitched.Controls.Clear();
			grpFriends.Controls.Clear();
			grpFollow.Controls.Clear();
			lblWait.Visible = true;
			bwQueryTwit.RunWorkerAsync();
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			var sets = Properties.Settings.Default;
			sets.FollowersLast = sets.FollowersNow;
			sets.FriendsLast = sets.FriendsNow;
			sets.Save();
			lblWait.Visible = true;
			grpLost.Controls.Clear();
			grpDitched.Controls.Clear();
			grpFriends.Controls.Clear();
			grpFollow.Controls.Clear();
			bwQueryTwit.RunWorkerAsync();
		}
	}
}
