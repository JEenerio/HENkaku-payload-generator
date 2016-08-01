namespace HENkakuPayloadGenerator
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.response1TextBox = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.response1Button = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.responseFilePathTextBox = new System.Windows.Forms.TextBox();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.createBaseExploitButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.response2Button = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.response2FilePathTextBox = new System.Windows.Forms.TextBox();
			this.response2TextBox = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.response3TextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.createNewPayloadButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(24, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Get";
			// 
			// response1TextBox
			// 
			this.response1TextBox.Location = new System.Drawing.Point(67, 19);
			this.response1TextBox.Name = "response1TextBox";
			this.response1TextBox.Size = new System.Drawing.Size(315, 20);
			this.response1TextBox.TabIndex = 2;
			this.response1TextBox.TextChanged += new System.EventHandler(this.response1TextBox_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.response1Button);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.responseFilePathTextBox);
			this.groupBox1.Controls.Add(this.response1TextBox);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(397, 76);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Request 1";
			// 
			// response1Button
			// 
			this.response1Button.Location = new System.Drawing.Point(282, 45);
			this.response1Button.Name = "response1Button";
			this.response1Button.Size = new System.Drawing.Size(100, 20);
			this.response1Button.TabIndex = 21;
			this.response1Button.Text = "Browse";
			this.response1Button.UseVisualStyleBackColor = true;
			this.response1Button.Click += new System.EventHandler(this.response1Button_Click);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(6, 49);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(55, 13);
			this.label17.TabIndex = 20;
			this.label17.Text = "Response";
			// 
			// responseFilePathTextBox
			// 
			this.responseFilePathTextBox.Location = new System.Drawing.Point(67, 45);
			this.responseFilePathTextBox.Name = "responseFilePathTextBox";
			this.responseFilePathTextBox.Size = new System.Drawing.Size(209, 20);
			this.responseFilePathTextBox.TabIndex = 19;
			this.responseFilePathTextBox.TextChanged += new System.EventHandler(this.responseFilePathTextBox_TextChanged);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// createBaseExploitButton
			// 
			this.createBaseExploitButton.Location = new System.Drawing.Point(150, 234);
			this.createBaseExploitButton.Name = "createBaseExploitButton";
			this.createBaseExploitButton.Size = new System.Drawing.Size(123, 23);
			this.createBaseExploitButton.TabIndex = 23;
			this.createBaseExploitButton.Text = "Create Base Payload";
			this.createBaseExploitButton.UseVisualStyleBackColor = true;
			this.createBaseExploitButton.Click += new System.EventHandler(this.createBaseExploitButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(279, 234);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(130, 23);
			this.cancelButton.TabIndex = 24;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.response2Button);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.response2FilePathTextBox);
			this.groupBox2.Controls.Add(this.response2TextBox);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(12, 94);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(397, 76);
			this.groupBox2.TabIndex = 22;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Request 2";
			// 
			// response2Button
			// 
			this.response2Button.Location = new System.Drawing.Point(282, 45);
			this.response2Button.Name = "response2Button";
			this.response2Button.Size = new System.Drawing.Size(100, 20);
			this.response2Button.TabIndex = 21;
			this.response2Button.Text = "Browse";
			this.response2Button.UseVisualStyleBackColor = true;
			this.response2Button.Click += new System.EventHandler(this.response2Button_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Response";
			// 
			// response2FilePathTextBox
			// 
			this.response2FilePathTextBox.Location = new System.Drawing.Point(67, 45);
			this.response2FilePathTextBox.Name = "response2FilePathTextBox";
			this.response2FilePathTextBox.Size = new System.Drawing.Size(209, 20);
			this.response2FilePathTextBox.TabIndex = 19;
			this.response2FilePathTextBox.TextChanged += new System.EventHandler(this.response2FilePathTextBox_TextChanged);
			// 
			// response2TextBox
			// 
			this.response2TextBox.Location = new System.Drawing.Point(67, 19);
			this.response2TextBox.Name = "response2TextBox";
			this.response2TextBox.Size = new System.Drawing.Size(315, 20);
			this.response2TextBox.TabIndex = 2;
			this.response2TextBox.TextChanged += new System.EventHandler(this.response2TextBox_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Get";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.response3TextBox);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Location = new System.Drawing.Point(12, 176);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(397, 52);
			this.groupBox3.TabIndex = 25;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "New Request";
			// 
			// response3TextBox
			// 
			this.response3TextBox.Location = new System.Drawing.Point(67, 19);
			this.response3TextBox.Name = "response3TextBox";
			this.response3TextBox.Size = new System.Drawing.Size(315, 20);
			this.response3TextBox.TabIndex = 2;
			this.response3TextBox.TextChanged += new System.EventHandler(this.response3TextBox_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 22);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(24, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Get";
			// 
			// createNewPayloadButton
			// 
			this.createNewPayloadButton.Location = new System.Drawing.Point(12, 234);
			this.createNewPayloadButton.Name = "createNewPayloadButton";
			this.createNewPayloadButton.Size = new System.Drawing.Size(130, 23);
			this.createNewPayloadButton.TabIndex = 26;
			this.createNewPayloadButton.Text = "Create New Payload";
			this.createNewPayloadButton.UseVisualStyleBackColor = true;
			this.createNewPayloadButton.Click += new System.EventHandler(this.createNewPayloadButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 266);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Controls.Add(this.createNewPayloadButton);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.createBaseExploitButton);
			this.Controls.Add(this.groupBox1);
			this.Name = "MainForm";
			this.Text = "HENkaku Payload Gen";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox response1TextBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox responseFilePathTextBox;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button response1Button;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Button createBaseExploitButton;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button response2Button;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox response2FilePathTextBox;
		private System.Windows.Forms.TextBox response2TextBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox response3TextBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button createNewPayloadButton;
	}
}

