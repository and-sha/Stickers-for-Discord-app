using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace stickers
{
    public partial class FormList : Form
    {
        public static Image PadImage(Image originalImage)
        {
            int largestDimension = Math.Max(originalImage.Height, originalImage.Width);
            Size squareSize = new Size(largestDimension, largestDimension);
            Bitmap squareImage = new Bitmap(squareSize.Width, squareSize.Height);
            using (Graphics graphics = Graphics.FromImage(squareImage))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, squareSize.Width, squareSize.Height);
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.DrawImage(originalImage, (squareSize.Width / 2) - (originalImage.Width / 2), (squareSize.Height / 2) - (originalImage.Height / 2), originalImage.Width, originalImage.Height);
            }
            return squareImage;
        }
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
        User user = new User();
        Server server = new Server();
        Pack pack = new Pack();
        List<string> names = new List<string>();
        List<string> files = new List<string>();
        string tmp;
        string flag;
        string currentSelect;
        public FormList()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Custom stickers");
            flag = String.Empty;
            tmp = File.ReadAllText("tmp");
            File.Delete("tmp");
            string json = File.ReadAllText("info.json");
            info = JsonConvert.DeserializeObject<Info>(json);
            foreach (var item in info.servers)
            {
                if (item.id == tmp)
                {
                    server = item;
                    flag = "s";
                    currentSelect = item.guildName;
                    break;
                }
            }
            foreach (var item in info.users)
            {
                if (item.id == tmp)
                {
                    user = item;
                    flag = "u";
                    currentSelect = item.username;
                    break;
                }
            }
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            if (flag == "s")
            {
                foreach (var item in server.customStickers)
                {
                    Directory.CreateDirectory("cache\\" + tmp);
                    string pth = $"cache\\{tmp}\\{item.url.Remove(0, 75)}";
                    if (File.Exists(pth)) { }
                    else
                    {
                        wc.DownloadFile(item.url, pth);
                        Image m = Image.FromFile(pth);
                        Image n = PadImage(m);
                        m.Dispose();
                        n.Save(pth);
                        n.Dispose();
                    }
                    imageList1.Images.Add(Image.FromFile(pth));
                    files.Add(pth);
                    names.Add($":{item.name}:");
                }
                foreach (var item in server.stickerPacks)
                {
                    comboBox1.Items.Add(item);
                }
            }
            if (flag == "u")
            {
                foreach (var item in user.customStickers)
                {
                    Directory.CreateDirectory("cache\\" + tmp);
                    string pth = $"cache\\{tmp}\\{item.url.Remove(0, 75)}";
                    if (File.Exists(pth)) { }
                    else
                    {
                        wc.DownloadFile(item.url, pth);
                        Image m = Image.FromFile(pth);
                        Image n = PadImage(m);
                        m.Dispose();
                        n.Save(pth);
                        n.Dispose();
                    }
                    imageList1.Images.Add(Image.FromFile(pth));
                    files.Add(pth);
                    names.Add($"-{item.name}");
                }
                foreach (var item in user.stickerPacks)
                {
                    comboBox1.Items.Add(item);
                }
            }
            listView1.View = View.LargeIcon;
            imageList1.ImageSize = new Size(128, 128);
            listView1.LargeImageList = imageList1;
            for (int j = 0; j < imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                item.Name = names[j];
                listView1.Items.Add(item);

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection v = listView1.SelectedItems;
            if (v.Count == 1)
            {
                ListViewItem s = v[0];
                int a = s.Index;
                string name = names[a];
                Clipboard.SetText(String.Concat(name));
                notifyIcon1.Visible = true;
                notifyIcon1.Text = currentSelect + "'s stickers";
                this.Hide();
            }
            else
            {
            }
        }
        private void resized(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.Text = currentSelect + "'s stickers";
                this.Hide();
            }
            Size size = this.Size;
            int h = size.Height;
            int w = size.Width;
            listView1.Height = h - 90;
            listView1.Width = w - 15;
            textBox1.Width = w - 180;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            files.Clear();
            names.Clear();
            imageList1.Images.Clear();
            listView1.Items.Clear();
            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            if (String.Concat(comboBox1.SelectedItem) == "Custom stickers")
            {
                if (flag == "s")
                {
                    foreach (var item in server.customStickers)
                    {
                        string pth = $"cache\\{tmp}\\{item.url.Remove(0, 75)}";
                        imageList1.Images.Add(Image.FromFile(pth));
                        files.Add(pth);
                        names.Add($":{item.name}:");
                    }
                    currentSelect = server.guildName;
                }
                if (flag == "u")
                {
                    foreach (var item in user.customStickers)
                    {
                        string pth = $"cache\\{tmp}\\{item.url.Remove(0, 75)}";
                        imageList1.Images.Add(Image.FromFile(pth));
                        files.Add(pth);
                        names.Add($"-{item.name}");
                    }
                    currentSelect = user.username;
                }
            }
            else
            {
                string flagpack = String.Empty;
                foreach (var item in info.packs)
                {
                    if (String.Concat(comboBox1.SelectedItem) == item.key)
                    {
                        flagpack = "has";
                        break;
                    }
                }
                if (flagpack != "has")
                {
                    string json = wc.DownloadString($"https://stickersfordiscord.com/api/sticker-packs/{comboBox1.SelectedItem}");
                    pack = JsonConvert.DeserializeObject<Pack>(json);
                    info.packs.Add(pack);
                    string ser = JsonConvert.SerializeObject(info);
                    File.WriteAllText("info.json", ser);
                }
                else
                {
                    foreach (var item in info.packs)
                    {
                        if (String.Concat(comboBox1.SelectedItem) == item.key)
                        {
                            pack = item;
                            break;
                        }
                    }
                }
                foreach (var item in pack.stickers)
                {
                    Directory.CreateDirectory("cache\\" + pack.key);
                    string pth = $"cache\\{pack.key}\\{item.url.Remove(0, 56)}";
                    if (File.Exists(pth)) { }
                    else
                    {
                        wc.DownloadFile(item.url, pth);
                        Image m = Image.FromFile(pth);
                        Image n = PadImage(m);
                        m.Dispose();
                        n.Save(pth);
                        n.Dispose();
                    }
                    imageList1.Images.Add(Image.FromFile(pth));
                    files.Add(pth);
                    names.Add($":{pack.key}-{item.name}:");
                }
            }
            currentSelect = pack.name;
            for (int j = 0; j < imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = j;
                item.Name = names[j];
                listView1.Items.Add(item);
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }
        
    }
    
}