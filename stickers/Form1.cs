using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace stickers
{
    public partial class FormSelect : Form
    {
        public class StickerManagers
        {
            public List<object> userIds { get; set; }
            public string roleId { get; set; }
        }

        public class Blacklist
        {
            public List<object> userIds { get; set; }
            public object roleId { get; set; }
        }

        public class Whitelist
        {
            public List<object> userIds { get; set; }
            public string roleId { get; set; }
        }

        public class CustomSticker
        {
            public string name { get; set; }
            public string url { get; set; }
            public string groupId { get; set; }
            public string groupType { get; set; }
            public string createdVia { get; set; }
            public DateTime createdAt { get; set; }
            public string creatorId { get; set; }
            public int uses { get; set; }
        }

        public class Server
        {
            public string id { get; set; }
            public string guildName { get; set; }
            public bool isActive { get; set; }
            public List<string> stickerPacks { get; set; }
            public List<string> guildManagerIds { get; set; }
            public StickerManagers stickerManagers { get; set; }
            public Blacklist blacklist { get; set; }
            public Whitelist whitelist { get; set; }
            public string listMode { get; set; }
            public List<CustomSticker> customStickers { get; set; }
            public string commandPrefix { get; set; }
            public string icon { get; set; }
        }
        public class User
        {
            public string id { get; set; }
            public List<object> createdStickerPacks { get; set; }
            public string username { get; set; }
            public List<string> stickerPacks { get; set; }
            public List<object> bans { get; set; }
            public List<CustomSticker> customStickers { get; set; }
            public string avatar { get; set; }
        }
        public class Sticker
        {
            public string name { get; set; }
            public string url { get; set; }
            public string groupId { get; set; }
            public string groupType { get; set; }
            public string createdVia { get; set; }
            public DateTime createdAt { get; set; }
            public string creatorId { get; set; }
            public int uses { get; set; }
        }

        public class Pack
        {
            public string name { get; set; }
            public string key { get; set; }
            public string description { get; set; }
            public string creatorId { get; set; }
            public List<Sticker> stickers { get; set; }
            public DateTime createdAt { get; set; }
            public int subscribers { get; set; }
            public bool listed { get; set; }
            public bool published { get; set; }
            public string icon { get; set; }
        }
        public class Info
        {
            public List<User> users { get; set; }
            public List<Server> servers { get; set; }
            public List<Pack> packs { get; set; }
        }
        Info info = new Info();
        List<String> ids = new List<String>();
        List<String> menus = new List<String>();
        public FormSelect()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            File.AppendAllText("info.json", String.Empty);
            string json = File.ReadAllText("info.json");
            if (json == String.Empty)
            {
                File.AppendAllText("info.json", "{\"users\":[],\"servers\":[],\"packs\":[]}");
                json = File.ReadAllText("info.json");
            }
            info = JsonConvert.DeserializeObject<Info>(json);
            try
            {
                foreach (var sus in info.servers)
                {
                    int count = sus.customStickers.Count;
                    string name = sus.guildName;
                    int packCount = sus.stickerPacks.Count;
                    string id = sus.id;
                    ids.Add(id);
                    string tmp = $"Server {name} ({count} stickers, {packCount} packs)";
                    menus.Add(tmp);
                    listBoxSelect.Items.Insert(listBoxSelect.Items.Count, tmp);
                }
            } catch (Exception)
            {
                info.servers = new List<Server>();
            }
            try
            {
                foreach (var sus in info.users)
                {
                    int count = sus.customStickers.Count;
                    string name = sus.username;
                    int packCount = sus.stickerPacks.Count;
                    string id = sus.id;
                    ids.Add(id);
                    string tmp = $"User {name} ({count} stickers, {packCount} packs)";
                    menus.Add(tmp);
                    listBoxSelect.Items.Insert(listBoxSelect.Items.Count, tmp);
                }
            }
            catch (Exception)
            {
                info.users = new List<User>();
            }
        }
        
        private void ButtonAddServer_Click(object sender, EventArgs e)
        {
            int isExist = 0;
            label1.Visible = true;
            errorIncorrect.SetIconAlignment(maskedTextBoxID, ErrorIconAlignment.MiddleRight);
            errorIncorrect.SetIconPadding(maskedTextBoxID, -20);
            errorIncorrect.BlinkRate = 250;
            errorIncorrect.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
                foreach (var i in info.users)
                {
                    if (i.id == maskedTextBoxID.Text) { isExist = 1; break; }
                }
                if (isExist != 1)
                {
                    string url = maskedTextBoxID.Text;
                    WebClient wc = new WebClient();
                    wc.Encoding = Encoding.UTF8;
                    try
                    {
                        string jsonr = wc.DownloadString($"https://stickersfordiscord.com/api/guilds/{url}");
                        Server server = JsonConvert.DeserializeObject<Server>(jsonr);
                        errorIncorrect.SetError(maskedTextBoxID, String.Empty);
                        int count = server.customStickers.Count;
                        string name = server.guildName;
                        int packCount = server.stickerPacks.Count;
                        string id = server.id;
                        ids.Add(id);
                        string tmp = $"Server {name} ({count} stickers, {packCount} packs)";
                        menus.Add(tmp);
                        listBoxSelect.Items.Insert(listBoxSelect.Items.Count, tmp);
                        info.servers.Add(server);
                        string ser = JsonConvert.SerializeObject(info);
                        File.WriteAllText("info.json", ser);
                    }
                    catch (WebException)
                    {
                        errorIncorrect.SetError(maskedTextBoxID, "Incorrect ID");
                    }
                } else { errorIncorrect.SetError(maskedTextBoxID, "This server is already here"); }
            label1.Visible = false;
        }

        private void ButtonAddUser_Click(object sender, EventArgs e)
        {
            int isЕxist = 0;
            label1.Visible = true;
            errorIncorrect.SetIconAlignment(maskedTextBoxID, ErrorIconAlignment.MiddleRight);
            errorIncorrect.SetIconPadding(maskedTextBoxID, -20);
            errorIncorrect.BlinkRate = 250;
            errorIncorrect.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;

                foreach (var i in info.users)
                {
                    if (i.id == maskedTextBoxID.Text) { isЕxist = 1; break; }
                }
                if (isЕxist != 1)
                {
                    string url = maskedTextBoxID.Text;
                    WebClient wc = new WebClient();
                    wc.Encoding = Encoding.UTF8;
                    try
                    {
                        string json = wc.DownloadString($"https://stickersfordiscord.com/api/users/{url}");
                        User user = JsonConvert.DeserializeObject<User>(json);
                        errorIncorrect.SetError(maskedTextBoxID, String.Empty);
                        int count = user.customStickers.Count;
                        string name = user.username;
                        int packCount = user.stickerPacks.Count;
                        string id = user.id;
                        string tmp = $"User {name} ({count} stickers, {packCount} packs)";
                        menus.Add(tmp);
                        listBoxSelect.Items.Insert(listBoxSelect.Items.Count, tmp);
                        ids.Add(id);
                        info.users.Add(user);
                        string ser = JsonConvert.SerializeObject(info);
                        File.WriteAllText("info.json", ser);
                    }
                    catch (WebException)
                    {
                        errorIncorrect.SetError(maskedTextBoxID, "Incorrect ID");
                    }
                }
                else { errorIncorrect.SetError(maskedTextBoxID, "This user is already here"); }
            label1.Visible = false;
        }

        private void listBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            string s = listBoxSelect.GetItemText(listBoxSelect.SelectedItem);
            string tmp = ids[menus.IndexOf(s)];
            File.WriteAllText("tmp", tmp);
            new FormList().Show();
            label1.Visible = false;
            notifyIcon1.Visible = true;
            this.Hide();
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            File.Delete("info.json");
            File.AppendAllText("info.json", "{\"users\":[],\"servers\":[],\"packs\":[]}");
            listBoxSelect.Items.Clear();
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            string json = File.ReadAllText("info.json");
            Info ne = JsonConvert.DeserializeObject<Info>(json);
            foreach (var i in info.servers)
            {
                string jsonr = wc.DownloadString($"https://stickersfordiscord.com/api/guilds/{i.id}");
                Server server = JsonConvert.DeserializeObject<Server>(jsonr);
                int count = server.customStickers.Count;
                string name = server.guildName;
                int packCount = server.stickerPacks.Count;
                string tmp = $"Server {name} ({count} stickers, {packCount} packs)";
                listBoxSelect.Items.Insert(listBoxSelect.Items.Count, tmp);
                ne.servers.Add(server);
                string ser = JsonConvert.SerializeObject(ne);
                File.WriteAllText("info.json", ser);
            }
            foreach (var i in info.users)
            {
                string jsonr = wc.DownloadString($"https://stickersfordiscord.com/api/users/{i.id}");
                User user = JsonConvert.DeserializeObject<User>(jsonr);
                int count = user.customStickers.Count;
                string name = user.username;
                int packCount = user.stickerPacks.Count;
                string tmp = $"User {name} ({count} stickers, {packCount} packs)";
                listBoxSelect.Items.Insert(listBoxSelect.Items.Count, tmp);
                ne.users.Add(user);
                string ser = JsonConvert.SerializeObject(ne);
                File.WriteAllText("info.json", ser);
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                this.WindowState = FormWindowState.Normal;
                this.Hide();
            }
        }
    }
}
