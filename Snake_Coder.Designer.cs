
namespace Assistant_Code
{
    partial class Snake_Coder
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_classeur = new System.Windows.Forms.Panel();
            this.lv_classeur = new System.Windows.Forms.ListView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btn_refresh_classeur = new System.Windows.Forms.ToolStripButton();
            this.btn_add_classeur = new System.Windows.Forms.ToolStripButton();
            this.btn_change_classeur = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btn_delete_classeur = new System.Windows.Forms.ToolStripButton();
            this.panel_documents = new System.Windows.Forms.Panel();
            this.lv_document = new System.Windows.Forms.ListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_refresh_documents = new System.Windows.Forms.ToolStripButton();
            this.btn_add_document = new System.Windows.Forms.ToolStripButton();
            this.btn_read_document = new System.Windows.Forms.ToolStripButton();
            this.panel_midle = new System.Windows.Forms.Panel();
            this.panel_border_R = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.debug = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_books = new System.Windows.Forms.Panel();
            this.add_book = new System.Windows.Forms.Button();
            this.btn_kill_all = new System.Windows.Forms.Button();
            this.btn_refresh_book = new System.Windows.Forms.Button();
            this.lv_book = new System.Windows.Forms.ListView();
            this.panel_classeur.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel_documents.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.panel_books.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_classeur
            // 
            this.panel_classeur.Controls.Add(this.lv_classeur);
            this.panel_classeur.Controls.Add(this.toolStrip2);
            this.panel_classeur.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_classeur.Location = new System.Drawing.Point(10, 184);
            this.panel_classeur.Name = "panel_classeur";
            this.panel_classeur.Size = new System.Drawing.Size(510, 455);
            this.panel_classeur.TabIndex = 3;
            // 
            // lv_classeur
            // 
            this.lv_classeur.BackColor = System.Drawing.Color.Black;
            this.lv_classeur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_classeur.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_classeur.ForeColor = System.Drawing.Color.White;
            this.lv_classeur.FullRowSelect = true;
            this.lv_classeur.HideSelection = false;
            this.lv_classeur.Location = new System.Drawing.Point(54, 0);
            this.lv_classeur.Name = "lv_classeur";
            this.lv_classeur.Size = new System.Drawing.Size(456, 455);
            this.lv_classeur.TabIndex = 0;
            this.lv_classeur.TileSize = new System.Drawing.Size(458, 24);
            this.lv_classeur.UseCompatibleStateImageBehavior = false;
            this.lv_classeur.View = System.Windows.Forms.View.Tile;
            this.lv_classeur.SelectedIndexChanged += new System.EventHandler(this.Select_Classeur_Behaviour);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_refresh_classeur,
            this.btn_add_classeur,
            this.btn_change_classeur,
            this.toolStripSeparator3,
            this.btn_delete_classeur});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(54, 455);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btn_refresh_classeur
            // 
            this.btn_refresh_classeur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_refresh_classeur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_refresh_classeur.Enabled = false;
            this.btn_refresh_classeur.Image = global::Assistant_Code.Properties.Resources.refresh;
            this.btn_refresh_classeur.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_refresh_classeur.Name = "btn_refresh_classeur";
            this.btn_refresh_classeur.Size = new System.Drawing.Size(52, 52);
            this.btn_refresh_classeur.Text = "rafraîchir la liste";
            this.btn_refresh_classeur.Click += new System.EventHandler(this.btn_refresh_classeur_Click);
            // 
            // btn_add_classeur
            // 
            this.btn_add_classeur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add_classeur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_add_classeur.Enabled = false;
            this.btn_add_classeur.Image = global::Assistant_Code.Properties.Resources.add_folder;
            this.btn_add_classeur.ImageTransparentColor = System.Drawing.Color.DarkMagenta;
            this.btn_add_classeur.Name = "btn_add_classeur";
            this.btn_add_classeur.Size = new System.Drawing.Size(52, 52);
            this.btn_add_classeur.Text = "ajouter un nouveau classeur";
            this.btn_add_classeur.Click += new System.EventHandler(this.btn_add_classeur_click);
            // 
            // btn_change_classeur
            // 
            this.btn_change_classeur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_change_classeur.Enabled = false;
            this.btn_change_classeur.Image = global::Assistant_Code.Properties.Resources.change;
            this.btn_change_classeur.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_change_classeur.Name = "btn_change_classeur";
            this.btn_change_classeur.Size = new System.Drawing.Size(52, 52);
            this.btn_change_classeur.Text = "toolStripButton1";
            this.btn_change_classeur.Click += new System.EventHandler(this.btn_rename_classeur);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(52, 6);
            // 
            // btn_delete_classeur
            // 
            this.btn_delete_classeur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_delete_classeur.Enabled = false;
            this.btn_delete_classeur.Image = global::Assistant_Code.Properties.Resources.delete;
            this.btn_delete_classeur.ImageTransparentColor = System.Drawing.Color.Orchid;
            this.btn_delete_classeur.Name = "btn_delete_classeur";
            this.btn_delete_classeur.Size = new System.Drawing.Size(52, 52);
            this.btn_delete_classeur.Text = "supprimer le classeur";
            this.btn_delete_classeur.Click += new System.EventHandler(this.btn_delete_click);
            // 
            // panel_documents
            // 
            this.panel_documents.Controls.Add(this.lv_document);
            this.panel_documents.Controls.Add(this.toolStrip1);
            this.panel_documents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_documents.Location = new System.Drawing.Point(549, 184);
            this.panel_documents.Name = "panel_documents";
            this.panel_documents.Size = new System.Drawing.Size(496, 455);
            this.panel_documents.TabIndex = 5;
            // 
            // lv_document
            // 
            this.lv_document.BackColor = System.Drawing.Color.Black;
            this.lv_document.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_document.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_document.ForeColor = System.Drawing.Color.White;
            this.lv_document.FullRowSelect = true;
            this.lv_document.HideSelection = false;
            this.lv_document.Location = new System.Drawing.Point(57, 0);
            this.lv_document.Name = "lv_document";
            this.lv_document.Size = new System.Drawing.Size(439, 455);
            this.lv_document.TabIndex = 1;
            this.lv_document.TileSize = new System.Drawing.Size(428, 24);
            this.lv_document.UseCompatibleStateImageBehavior = false;
            this.lv_document.View = System.Windows.Forms.View.Tile;
            this.lv_document.SelectedIndexChanged += new System.EventHandler(this.Select_document_Behaviour);
            this.lv_document.DoubleClick += new System.EventHandler(this.read_document);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_refresh_documents,
            this.btn_add_document,
            this.btn_read_document});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(57, 455);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_refresh_documents
            // 
            this.btn_refresh_documents.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_refresh_documents.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_refresh_documents.Enabled = false;
            this.btn_refresh_documents.Image = global::Assistant_Code.Properties.Resources.refresh;
            this.btn_refresh_documents.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_refresh_documents.Name = "btn_refresh_documents";
            this.btn_refresh_documents.Size = new System.Drawing.Size(55, 52);
            this.btn_refresh_documents.Text = "rafraîchir la liste";
            this.btn_refresh_documents.Click += new System.EventHandler(this.btn_refresh_documents_Click);
            // 
            // btn_add_document
            // 
            this.btn_add_document.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_add_document.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_add_document.Enabled = false;
            this.btn_add_document.Image = global::Assistant_Code.Properties.Resources.add_document;
            this.btn_add_document.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_add_document.Name = "btn_add_document";
            this.btn_add_document.Size = new System.Drawing.Size(55, 52);
            this.btn_add_document.Text = "ajouter un chapitre";
            this.btn_add_document.Click += new System.EventHandler(this.btn_add_document_Click);
            // 
            // btn_read_document
            // 
            this.btn_read_document.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_read_document.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btn_read_document.Enabled = false;
            this.btn_read_document.Image = global::Assistant_Code.Properties.Resources.read;
            this.btn_read_document.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_read_document.Name = "btn_read_document";
            this.btn_read_document.Size = new System.Drawing.Size(55, 52);
            this.btn_read_document.Text = "lire un chapitre";
            this.btn_read_document.Click += new System.EventHandler(this.btn_read_document_Click);
            // 
            // panel_midle
            // 
            this.panel_midle.BackColor = System.Drawing.Color.DimGray;
            this.panel_midle.BackgroundImage = global::Assistant_Code.Properties.Resources.cuir;
            this.panel_midle.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_midle.Location = new System.Drawing.Point(520, 184);
            this.panel_midle.Name = "panel_midle";
            this.panel_midle.Size = new System.Drawing.Size(29, 455);
            this.panel_midle.TabIndex = 4;
            // 
            // panel_border_R
            // 
            this.panel_border_R.BackColor = System.Drawing.Color.DimGray;
            this.panel_border_R.BackgroundImage = global::Assistant_Code.Properties.Resources.cuir;
            this.panel_border_R.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_border_R.Location = new System.Drawing.Point(1045, 184);
            this.panel_border_R.Name = "panel_border_R";
            this.panel_border_R.Size = new System.Drawing.Size(21, 455);
            this.panel_border_R.TabIndex = 1;
            // 
            // panel_bottom
            // 
            this.panel_bottom.BackgroundImage = global::Assistant_Code.Properties.Resources.cuir;
            this.panel_bottom.Controls.Add(this.debug);
            this.panel_bottom.Controls.Add(this.label1);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(10, 639);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(1056, 42);
            this.panel_bottom.TabIndex = 9;
            // 
            // debug
            // 
            this.debug.BackColor = System.Drawing.Color.Transparent;
            this.debug.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.debug.ForeColor = System.Drawing.Color.Gold;
            this.debug.Location = new System.Drawing.Point(6, 10);
            this.debug.Name = "debug";
            this.debug.Size = new System.Drawing.Size(382, 23);
            this.debug.TabIndex = 1;
            this.debug.Text = "< o___o >";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(658, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "copyright 2022 . ANAHOA Studio . Snake";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.BackgroundImage = global::Assistant_Code.Properties.Resources.cuir;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 497);
            this.panel2.TabIndex = 8;
            // 
            // panel_books
            // 
            this.panel_books.BackColor = System.Drawing.Color.DimGray;
            this.panel_books.BackgroundImage = global::Assistant_Code.Properties.Resources.cuir;
            this.panel_books.Controls.Add(this.add_book);
            this.panel_books.Controls.Add(this.btn_kill_all);
            this.panel_books.Controls.Add(this.btn_refresh_book);
            this.panel_books.Controls.Add(this.lv_book);
            this.panel_books.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_books.Location = new System.Drawing.Point(0, 0);
            this.panel_books.Name = "panel_books";
            this.panel_books.Size = new System.Drawing.Size(1066, 184);
            this.panel_books.TabIndex = 0;
            // 
            // add_book
            // 
            this.add_book.AutoSize = true;
            this.add_book.BackgroundImage = global::Assistant_Code.Properties.Resources.add_book;
            this.add_book.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.add_book.Location = new System.Drawing.Point(13, 12);
            this.add_book.Name = "add_book";
            this.add_book.Size = new System.Drawing.Size(55, 54);
            this.add_book.TabIndex = 4;
            this.add_book.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.add_book.UseVisualStyleBackColor = true;
            this.add_book.Click += new System.EventHandler(this.add_book_Click);
            // 
            // btn_kill_all
            // 
            this.btn_kill_all.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_kill_all.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_kill_all.Location = new System.Drawing.Point(932, 12);
            this.btn_kill_all.Name = "btn_kill_all";
            this.btn_kill_all.Size = new System.Drawing.Size(118, 54);
            this.btn_kill_all.TabIndex = 3;
            this.btn_kill_all.Text = "Détruire tout";
            this.btn_kill_all.UseVisualStyleBackColor = true;
            this.btn_kill_all.Click += new System.EventHandler(this.btn_kill_all_data);
            // 
            // btn_refresh_book
            // 
            this.btn_refresh_book.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refresh_book.Location = new System.Drawing.Point(78, 12);
            this.btn_refresh_book.Name = "btn_refresh_book";
            this.btn_refresh_book.Size = new System.Drawing.Size(118, 54);
            this.btn_refresh_book.TabIndex = 2;
            this.btn_refresh_book.Text = "Rafraîchir";
            this.btn_refresh_book.UseVisualStyleBackColor = true;
            this.btn_refresh_book.Click += new System.EventHandler(this.refresh_list_book);
            // 
            // lv_book
            // 
            this.lv_book.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_book.AutoArrange = false;
            this.lv_book.BackColor = System.Drawing.Color.DimGray;
            this.lv_book.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_book.ForeColor = System.Drawing.Color.MistyRose;
            this.lv_book.FullRowSelect = true;
            this.lv_book.GridLines = true;
            this.lv_book.HideSelection = false;
            this.lv_book.Location = new System.Drawing.Point(13, 72);
            this.lv_book.MultiSelect = false;
            this.lv_book.Name = "lv_book";
            this.lv_book.Size = new System.Drawing.Size(1037, 94);
            this.lv_book.TabIndex = 0;
            this.lv_book.TileSize = new System.Drawing.Size(1000, 24);
            this.lv_book.UseCompatibleStateImageBehavior = false;
            this.lv_book.View = System.Windows.Forms.View.Tile;
            this.lv_book.SelectedIndexChanged += new System.EventHandler(this.Select_Book_Behaviour);
            // 
            // Snake_Coder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 681);
            this.Controls.Add(this.panel_documents);
            this.Controls.Add(this.panel_midle);
            this.Controls.Add(this.panel_classeur);
            this.Controls.Add(this.panel_border_R);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_books);
            this.Name = "Snake_Coder";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel_classeur.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel_documents.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel_bottom.ResumeLayout(false);
            this.panel_books.ResumeLayout(false);
            this.panel_books.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_books;
        private System.Windows.Forms.Panel panel_border_R;
        private System.Windows.Forms.Panel panel_classeur;
        private System.Windows.Forms.ListView lv_classeur;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Panel panel_midle;
        private System.Windows.Forms.Panel panel_documents;
        private System.Windows.Forms.ListView lv_document;
        private System.Windows.Forms.ListView lv_book;
        private System.Windows.Forms.ToolStripButton btn_add_classeur;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_add_document;
        private System.Windows.Forms.ToolStripButton btn_delete_classeur;
        private System.Windows.Forms.ToolStripButton btn_read_document;
        private System.Windows.Forms.Button btn_kill_all;
        private System.Windows.Forms.Button btn_refresh_book;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btn_refresh_classeur;
        private System.Windows.Forms.ToolStripButton btn_refresh_documents;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label debug;
        private System.Windows.Forms.ToolStripButton btn_change_classeur;
        private System.Windows.Forms.Button add_book;
    }
}

