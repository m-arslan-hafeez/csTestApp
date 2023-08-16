using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace csTestApp
{
    public partial class frmMain : Form
    {

        //[DllImport("EncDecLibrary.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        //public static extern bool SetDllDirectory(string lpPathName);

        const string dll_path = "EncDecLibrary.dll";
        [DllImport(dll_path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void encryptFile(string file_name, string address, int key, string output_file_path);
        [DllImport(dll_path, CallingConvention = CallingConvention.Cdecl)]
        public static extern void decryptFile(string file_name, string address, int key, string file_type);


        String file_name;
        int user_key;
        String extension;


        RadioButton rbtEncrypt = new RadioButton();
        Label lblFileName = new Label();
        Label lblKey = new Label();
        TextBox tbFileName = new TextBox();
        Label lblAddress = new Label();
        TextBox tbAddress = new TextBox();
        Button btnBrowse = new Button();
        TextBox tbKey = new TextBox();
        Button btnEncrypt = new Button();
        RadioButton rbtDecrypt = new RadioButton();
        Label lblFileName2 = new Label();
        TextBox tbFileName2 = new TextBox();
        Button btnBrowse2 = new Button();
        Label lblKey2 = new Label();
        TextBox tbKey2 = new TextBox();
        Label lblExtension = new Label();
        ComboBox cbExtension = new ComboBox();
        Button btnDecrypt = new Button();

        public frmMain()
        {
            InitializeComponent();

            this.Controls.Add(rbtDecrypt);
            rbtEncrypt.AutoSize = true;
            rbtEncrypt.Location = new System.Drawing.Point(37, 34);
            rbtEncrypt.Name = "rbtEncrypt";
            rbtEncrypt.Size = new System.Drawing.Size(75, 17);
            rbtEncrypt.TabIndex = 0;
            rbtEncrypt.TabStop = true;
            rbtEncrypt.Text = "Encryption";
            rbtEncrypt.UseVisualStyleBackColor = true;
            rbtEncrypt.CheckedChanged += new System.EventHandler(this.rbtEncrypt_CheckedChanged);

            this.Controls.Add(rbtEncrypt);
            rbtDecrypt.AutoSize = true;
            rbtDecrypt.Location = new System.Drawing.Point(229, 34);
            rbtDecrypt.Name = "rbtDecrypt";
            rbtDecrypt.Size = new System.Drawing.Size(76, 17);
            rbtDecrypt.TabIndex = 1;
            rbtDecrypt.TabStop = true;
            rbtDecrypt.Text = "Decryption";
            rbtDecrypt.UseVisualStyleBackColor = true;
            rbtDecrypt.CheckedChanged += new System.EventHandler(this.rbtDecrypt_CheckedChanged);

            this.Controls.Add(lblFileName);
            lblFileName.AutoSize = true;
            lblFileName.Location = new System.Drawing.Point(37, 74);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new System.Drawing.Size(57, 13);
            lblFileName.TabIndex = 4;
            lblFileName.Text = "File Name:";

            this.Controls.Add(tbFileName);
            tbFileName.Location = new System.Drawing.Point(97, 74);
            tbFileName.Name = "tbFileName";
            tbFileName.Size = new System.Drawing.Size(189, 20);
            tbFileName.TabIndex = 2;
            tbFileName.Visible = false;

            //this.Controls.Add(lblAddress);
            //lblAddress.AutoSize = true;
            //lblAddress.Location = new System.Drawing.Point(37, 104);
            //lblAddress.Name = "lblAddress";
            //lblAddress.Size = new System.Drawing.Size(57, 13);
            //lblAddress.TabIndex = 3;
            //lblAddress.Text = "File Address:";

            //this.Controls.Add(tbAddress);
            //tbFileName.Location = new System.Drawing.Point(97, 104);
            //tbFileName.Name = "tbFileName";
            //tbFileName.Size = new System.Drawing.Size(189, 20);
            //tbFileName.TabIndex = 5;
            //tbFileName.Visible = false;


            this.Controls.Add(btnBrowse);
            btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            btnBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnBrowse.Location = new System.Drawing.Point(239, 94);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new System.Drawing.Size(47, 23);
            btnBrowse.TabIndex = 14;
            btnBrowse.Text = "...";
            btnBrowse.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Visible = false;
            btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            this.Controls.Add(lblKey);
            lblKey.AutoSize = true;
            lblKey.Location = new System.Drawing.Point(37, 130);
            lblKey.Name = "lblKey";
            lblKey.Size = new System.Drawing.Size(28, 13);
            lblKey.TabIndex = 5;
            lblKey.Text = "Key:";

            this.Controls.Add(tbKey);
            tbKey.Location = new System.Drawing.Point(97, 123);
            tbKey.Name = "tbKey";
            tbKey.Size = new System.Drawing.Size(189, 20);
            tbKey.TabIndex = 3;
            tbKey.Visible = false;

            this.Controls.Add(btnEncrypt);
            btnEncrypt.Location = new System.Drawing.Point(144, 171);
            btnEncrypt.Name = "btnEncrypt";
            btnEncrypt.Size = new System.Drawing.Size(75, 23);
            btnEncrypt.TabIndex = 6;
            btnEncrypt.Text = "Encrypt";
            btnEncrypt.UseVisualStyleBackColor = true;
            btnEncrypt.Visible = false;
            btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);

            this.Controls.Add(lblFileName2);
            lblFileName2.AutoSize = true;
            lblFileName2.Location = new System.Drawing.Point(79, 74);
            lblFileName2.Name = "lblFileName2";
            lblFileName2.Size = new System.Drawing.Size(57, 13);
            lblFileName2.TabIndex = 9;
            lblFileName2.Text = "File Name:";
            lblFileName2.Visible = false;

            this.Controls.Add(tbFileName2);
            tbFileName2.Location = new System.Drawing.Point(139, 74);
            tbFileName2.Name = "tbFileName2";
            tbFileName2.Size = new System.Drawing.Size(189, 20);
            tbFileName2.TabIndex = 7;
            tbFileName2.Visible = false;

            this.Controls.Add(btnBrowse2);
            btnBrowse2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            btnBrowse2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnBrowse2.Location = new System.Drawing.Point(281, 94);
            btnBrowse2.Name = "btnBrowse2";
            btnBrowse2.Size = new System.Drawing.Size(47, 23);
            btnBrowse2.TabIndex = 15;
            btnBrowse2.Text = "...";
            btnBrowse2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            btnBrowse2.UseVisualStyleBackColor = true;
            btnBrowse2.Visible = false;
            btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);

            this.Controls.Add(lblKey);
            lblKey2.AutoSize = true;
            lblKey2.Location = new System.Drawing.Point(79, 130);
            lblKey2.Name = "lblKey2";
            lblKey2.Size = new System.Drawing.Size(28, 13);
            lblKey2.TabIndex = 10;
            lblKey2.Text = "Key";

            this.Controls.Add(tbKey2);
            this.tbKey2.Location = new System.Drawing.Point(139, 123);
            this.tbKey2.Name = "tbKey2";
            this.tbKey2.Size = new System.Drawing.Size(189, 20);
            this.tbKey2.TabIndex = 8;
            this.tbKey2.Visible = false;

            Controls.Add(lblExtension);
            lblExtension.AutoSize = true;
            lblExtension.Location = new System.Drawing.Point(80, 168);
            lblExtension.Name = "lblExtension";
            lblExtension.Size = new System.Drawing.Size(56, 13);
            lblExtension.TabIndex = 13;
            lblExtension.Text = "Extension:";
            lblExtension.Visible = false;

            Controls.Add(cbExtension);
            cbExtension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbExtension.Items.AddRange(new object[] {
            ".docs",
            ".jpg",
            ".pdf",
            ".png",
            ".xlsx"});
            cbExtension.Location = new System.Drawing.Point(144, 168);
            cbExtension.Name = "cbExtension";
            cbExtension.Size = new System.Drawing.Size(165, 21);
            cbExtension.Sorted = true;
            cbExtension.TabIndex = 16;
            cbExtension.TabStop = false;
            cbExtension.Visible = false;

            this.Controls.Add(btnDecrypt);
            btnDecrypt.Location = new System.Drawing.Point(183, 200);
            btnDecrypt.Name = "btnDecrypt";
            btnDecrypt.Size = new System.Drawing.Size(75, 23);
            btnDecrypt.TabIndex = 11;
            btnDecrypt.Text = "Decrypt";
            btnDecrypt.UseVisualStyleBackColor = true;
            btnDecrypt.Visible = false;
            btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
        }

        private void rbtEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            lblFileName2.Visible = false;
            tbFileName2.Visible = false;
            lblKey2.Visible = false;
            tbKey2.Visible = false;
            btnBrowse2.Visible = false;
            lblExtension.Visible = false;
            btnDecrypt.Visible = false;
            cbExtension.Visible = false;

            lblFileName.Visible = true;
            tbFileName.Visible = true;
            lblKey.Visible = true;
            btnBrowse.Visible = true;
            tbKey.Visible = true;
            btnEncrypt.Visible = true;
            lblAddress.Visible = true;
            tbAddress.Visible = true;
 
    }

        private void rbtDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            lblFileName.Visible = false;
            tbFileName.Visible = false;
            lblKey.Visible = false;
            btnBrowse.Visible = false;
            tbKey.Visible = false;
            btnEncrypt.Visible = false;

            lblFileName2.Visible = true;
            tbFileName2.Visible = true;
            lblKey2.Visible = true;
            tbKey2.Visible = true;
            btnBrowse2.Visible = true;
            lblExtension.Visible = true;
            btnDecrypt.Visible = true;
            cbExtension.Visible = true;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            MessageBox.Show("File : " + tbFileName.Text + " Encrypted successfully with Key : " + tbKey.Text);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All Files (*.*)|*.*";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    string fileName = Path.GetFileName(selectedFile);
                    //FileInfo fileInfo = new FileInfo(selectedFile);
                    //long fileSize = fileInfo.Length;                    
                    tbFileName.Text = fileName;

                }
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            //file_name = tbFileName2.Text.ToString();
            //user_key = int.Parse(tbKey2.Text);
            //extension = cbExtension.Text.ToString();

            MessageBox.Show("File : " + file_name + " Decrypted successfully with Key : " + user_key + " and Extension " + extension);
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Encrypted Files |*.enc";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    string fileName = Path.GetFileName(selectedFile);
                    //FileInfo fileInfo = new FileInfo(selectedFile);
                    //long fileSize = fileInfo.Length;                    
                    tbFileName2.Text = fileName;

                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
