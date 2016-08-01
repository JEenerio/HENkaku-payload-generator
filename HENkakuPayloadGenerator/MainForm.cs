using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HENkakuPayloadGenerator
{
	public partial class MainForm : Form
	{
		private UInt32[,] addressArray = new UInt32[3,7];
		private string basePayloadFile = "base_payload.bin";
		private string newPayloadFile = "new_payload.bin";
		private string offsetFile = "offsets.txt";

		public MainForm()
		{
			InitializeComponent();
			EnableStuff();
		}

		private void response1TextBox_TextChanged(object sender, EventArgs e)
		{
			SetAddresses(response1TextBox.Text, 0);
		}

		private void response2TextBox_TextChanged(object sender, EventArgs e)
		{
			SetAddresses(response2TextBox.Text, 1);
		}

		private void response3TextBox_TextChanged(object sender, EventArgs e)
		{
			SetAddresses(response3TextBox.Text, 2);
		}

		private void response1Button_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.Title = "Browse Payload Files";
			openFileDialog1.CheckFileExists = true;
			openFileDialog1.CheckPathExists = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				responseFilePathTextBox.Text = openFileDialog1.FileName;
			}
		}

		private void SetAddresses(string request, int responseNum)
		{
			for (int i = 0; i < 7; i++)
			{
				addressArray[responseNum,i] = 0;
			}

			var parts = request.Split(new[] { "&", "?" }, StringSplitOptions.RemoveEmptyEntries);

			foreach (var part in parts)
			{
				var regex = @"a(?<addNum>\d)=(?<address>.*)";
				var match = Regex.Match(part.ToLower(), regex);
				if (match.Success)
				{
					var addressNum = Int32.Parse(match.Groups["addNum"].Value);
					addressArray[responseNum, addressNum - 1] = UInt32.Parse(match.Groups["address"].Value, System.Globalization.NumberStyles.AllowHexSpecifier);
				}
			}

			EnableStuff();
		}

		private void createBaseExploitButton_Click(object sender, EventArgs e)
		{
			var responseFile = new FileInfo(responseFilePathTextBox.Text);
			var response2File = new FileInfo(response2FilePathTextBox.Text);

			if (!responseFile.Exists || !response2File.Exists)
			{
				throw new InvalidOperationException("Response file does not exist");
			}

			CreateBasePayload(responseFile, response2File);

			EnableStuff();
		}

		private void EnableStuff()
		{
			createBaseExploitButton.Enabled = false;
			createNewPayloadButton.Enabled = false;

			try
			{
				if (!string.IsNullOrEmpty(response1TextBox.Text) &&
					!string.IsNullOrEmpty(response2TextBox.Text) &&
					File.Exists(responseFilePathTextBox.Text) &&
					File.Exists(response2FilePathTextBox.Text) &&
					ResponseAddressesSet())
				{
					createBaseExploitButton.Enabled = true;
				}
			}
			catch { }

			if (File.Exists(basePayloadFile) && File.Exists(offsetFile))
				createNewPayloadButton.Enabled = true;
			
		}

		private void response2Button_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog();
			openFileDialog1.Title = "Browse Payload Files";
			openFileDialog1.CheckFileExists = true;
			openFileDialog1.CheckPathExists = true;

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				response2FilePathTextBox.Text = openFileDialog1.FileName;
			}
		}

		private void responseFilePathTextBox_TextChanged(object sender, EventArgs e)
		{
			EnableStuff();
		}

		private void response2FilePathTextBox_TextChanged(object sender, EventArgs e)
		{
			EnableStuff();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private bool ResponseAddressesSet()
		{
			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					if (addressArray[i,j] == 0)
						return false;
				}
			}
			return true;
		}

		private void CreateBasePayload(FileInfo response1File, FileInfo response2File)
		{
			var responseBytes = File.ReadAllBytes(response1File.FullName);
			var response2Bytes = File.ReadAllBytes(response2File.FullName);
			var list = new System.Collections.Generic.List<UInt32>();
			var offsets = new System.Collections.Generic.Dictionary<int, UInt32>();
			var offsetOutput = "";
			UInt32[] addressDifferences = new UInt32[7];

			if (responseBytes.Length != response2Bytes.Length)
				throw new InvalidOperationException("The 2 responses must be of equal length");

			for (int i = 0; i < 7; i++)
			{
				if (addressArray[0, i] > addressArray[1, i])
					addressDifferences[i] = addressArray[0, i] - addressArray[1, i];
				else
					addressDifferences[i] = addressArray[1, i] - addressArray[0, i];
			}

			for (int i = 0; i < responseBytes.Length; i += 4)
			{
				UInt32 int1 = (UInt32)(responseBytes[i] | responseBytes[i + 1] << 8 | responseBytes[i + 2] << 16 | responseBytes[i + 3] << 24);
				UInt32 int2 = (UInt32)(response2Bytes[i] | response2Bytes[i + 1] << 8 | response2Bytes[i + 2] << 16 | response2Bytes[i + 3] << 24);

				if (int1 > int2)
				{
					var diff = int1 - int2;
					offsetOutput += string.Format("{0:x}:{1}\r\n", i, GetAddressFromDifference(diff, addressDifferences));

					if (!list.Contains(diff))
						list.Add(diff);

					offsets.Add(i, diff);
				}
				else if (int2 > int1)
				{
					var diff = int2 - int1;
					offsetOutput += string.Format("{0:x}:{1}\r\n", i, GetAddressFromDifference(diff, addressDifferences));

					if (!list.Contains(diff))
						list.Add(diff);

					offsets.Add(i, diff);

				}

			}

			File.WriteAllText(offsetFile, offsetOutput);

			var basePayload = new byte[responseBytes.Length];

			UInt32 a1 = addressArray[0, 0];
			UInt32 a2 = addressArray[0, 1];
			UInt32 a3 = addressArray[0, 2];
			UInt32 a4 = addressArray[0, 3];
			UInt32 a5 = addressArray[0, 4];
			UInt32 a6 = addressArray[0, 5];
			UInt32 a7 = addressArray[0, 6];


			for (int i = 0; i < responseBytes.Length; i += 4)
			{
				System.UInt32 actualAddress = (UInt32)(responseBytes[i] | responseBytes[i + 1] << 8 | responseBytes[i + 2] << 16 | responseBytes[i + 3] << 24);
				long baseAddress = 0;

				if (offsets.Keys.Contains(i))
				{
					var offset = (long)offsets[i];

					if (offset == addressDifferences[0])
						baseAddress = (long)actualAddress - (long)a1;
					else if (offset == addressDifferences[1])
						baseAddress = (long)actualAddress - (long)a2;
					else if (offset == addressDifferences[2])
						baseAddress = (long)actualAddress - (long)a3;
					else if (offset == addressDifferences[3])
						baseAddress = (long)actualAddress - (long)a4;
					else if (offset == addressDifferences[4])
						baseAddress = (long)actualAddress - (long)a5;
					else if (offset == addressDifferences[5])
						baseAddress = (long)actualAddress - (long)a6;
					else if (offset == addressDifferences[6])
						baseAddress = (long)actualAddress - (long)a7;

					basePayload[i] = (byte)(baseAddress & 0xff);
					basePayload[i + 1] = (byte)(baseAddress >> 8 & 0xff);
					basePayload[i + 2] = (byte)(baseAddress >> 16 & 0xff);
					basePayload[i + 3] = (byte)(baseAddress >> 24 & 0xff);
				}
				else
				{
					basePayload[i] = responseBytes[i];
					basePayload[i + 1] = responseBytes[i + 1];
					basePayload[i + 2] = responseBytes[i + 2];
					basePayload[i + 3] = responseBytes[i + 3];
				}
			}

			System.IO.File.WriteAllBytes(basePayloadFile, basePayload);

			MessageBox.Show("Base payload successfully created!");
		}

		private string GetAddressFromDifference(UInt32 diff, UInt32[] differences)
		{
			for (int i = 0; i < differences.Length; i++)
			{
				if (diff == differences[i])
				{
					return "a" + (i + 1);
				}
			}

			return "";
		}

		private void createNewPayloadButton_Click(object sender, EventArgs e)
		{
			var offsetsText = File.ReadAllText(offsetFile);
			var fileOffsetToAddress = new Dictionary<int, int>();

			var offsets = offsetsText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < offsets.Length; i ++)
			{
				var offsetParts = offsets[i].Split(':');
				var addressIndex = 0;
				switch (offsetParts[1])
				{
					case "a1":
						addressIndex = 0;
						break;
					case "a2":
						addressIndex = 1;
						break;
					case "a3":
						addressIndex = 2;
						break;
					case "a4":
						addressIndex = 3;
						break;
					case "a5":
						addressIndex = 4;
						break;
					case "a6":
						addressIndex = 5;
						break;
					case "a7":
						addressIndex = 6;
						break;
				}
				fileOffsetToAddress.Add(Int32.Parse(offsetParts[0], System.Globalization.NumberStyles.AllowHexSpecifier), addressIndex);
			}

			var list = new List<UInt32>();
			
			var bytes = File.ReadAllBytes(basePayloadFile);

			UInt32 a1 = addressArray[2, 0];
			UInt32 a2 = addressArray[2, 1];
			UInt32 a3 = addressArray[2, 2];
			UInt32 a4 = addressArray[2, 3];
			UInt32 a5 = addressArray[2, 4];
			UInt32 a6 = addressArray[2, 5];
			UInt32 a7 = addressArray[2, 6];

			var newPayload = new byte[bytes.Length];

			for (int i = 0; i < bytes.Length; i += 4)
			{
				System.UInt32 offset = (UInt32)(bytes[i] | bytes[i + 1] << 8 | bytes[i + 2] << 16 | bytes[i + 3] << 24);

				if (fileOffsetToAddress.ContainsKey(i))
				{
					UInt32 newValue = 0;

					switch (fileOffsetToAddress[i])
					{
						case 0:
							newValue = a1 + offset;
							break;
						case 1:
							newValue = a2 + offset;
							break;
						case 2:
							newValue = a3 + offset;
							break;
						case 3:
							newValue = a4 + offset;
							break;
						case 4:
							newValue = a5 + offset;
							break;
						case 5:
							newValue = a6 + offset;
							break;
						case 6:
							newValue = a7 + offset;
							break;
					}

					newPayload[i] = (byte)(newValue & 0xff);
					newPayload[i + 1] = (byte)(newValue >> 8 & 0xff);
					newPayload[i + 2] = (byte)(newValue >> 16 & 0xff);
					newPayload[i + 3] = (byte)(newValue >> 24 & 0xff);
				}
				else
				{
					newPayload[i] = bytes[i];
					newPayload[i + 1] = bytes[i + 1];
					newPayload[i + 2] = bytes[i + 2];
					newPayload[i + 3] = bytes[i + 3];
				}

			}

			File.WriteAllBytes(newPayloadFile, newPayload);

			MessageBox.Show("New payload created!");
		}
	}
}
