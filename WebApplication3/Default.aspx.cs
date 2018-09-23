using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Drawing;

namespace WebApplication3
{
	public partial class _Default : System.Web.UI.Page
	{
		public _Default()
		{
			Rows = 9;
			Columns = 9;
			DefaultImage = "zero.png";
		}
		protected void Page_Init(object sender, EventArgs e)
		{
			img = new ImageButton[Rows][];
			for (int i = 0; i < img.Length; i++) {
				img[i] = new ImageButton[Columns];
				tbl.Rows.Add(new TableRow());
				for (int j = 0; j < img[i].Length; j++) {
					img[i][j] = new ImageButton();
					img[i][j].Width = new Unit(25);
					if (!IsPostBack) {
						img[i][j].ImageUrl = DefaultImage;
					}
					tbl.Rows[i].Cells.Add(new TableCell());
					tbl.Rows[i].Cells[j].Controls.Add(img[i][j]);
				}
			}
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			for (int i = 0; i < img.Length; i++) {
				for (int j = 0; j < img[i].Length; j++) {
					if (!IsPostBack) {
						img[i][j].ImageUrl = DefaultImage;
					}
					((TableCell)img[i][j].Parent).BorderColor = Color.Black;

					img[i][j].Click += new ImageClickEventHandler(Primary_Click);
				}
			}
		}

		void Primary_Click(object sender, ImageClickEventArgs e)
		{
			((ImageButton)sender).ImageUrl = "one.png";
			//((TableCell)((ImageButton)sender).Parent).BorderColor = Color.Red;
			//TableRow row = ((TableRow)((ImageButton)sender).Parent.Parent);

			int r = tbl.Rows.GetRowIndex((TableRow)((ImageButton)sender).Parent.Parent);
			RowIndex = r;
			int c = tbl.Rows[r].Cells.GetCellIndex((TableCell)((ImageButton)sender).Parent);
			ColumnIndex = c;

			// show indication of row selection
			for (int i = 0; i < Columns; i++) {
				((TableCell)img[r][i].Parent).BorderColor = Color.Red;
			}

			// show indication of row selection
			for (int i = 0; i < Rows; i++) {
				((TableCell)img[i][c].Parent).BorderColor = Color.Red;
			}

			//int n = (Columns + Rows) / 2;
		//	int r = 3;
		//	int c = 3;
			int rO = 3 * (RowIndex / 3);
			int cO = 3 * (ColumnIndex / 3);
			for (int i = 0; i < 3; i++) {
				for (int j = 0; j < 3; j++) {
					((TableCell)img[i+rO][j+cO].Parent).BorderColor = Color.Blue;
				}
			}
		}
		protected void Secondary_Click(object sender, ImageClickEventArgs e)
		{
			img[RowIndex][ColumnIndex].ImageUrl = ((ImageButton)sender).ImageUrl;
		}
		protected override void LoadViewState(object savedState)
		{
			if (savedState != null) {
				object[] allState = (object[])savedState;
				if (allState[0] != null)
					base.LoadViewState(savedState);
				if (allState[1] != null)
					RowIndex = (int)allState[1];
				if (allState[2] != null)
					ColumnIndex = (int)allState[2];
			}
		}
		protected override object SaveViewState()
		{
			object[] allState = new object[3];
			allState[0] = base.SaveViewState();
			allState[1] = RowIndex;
			allState[2] = ColumnIndex;
			return allState;
		}
		public int RowIndex { get; set; }
		public int ColumnIndex { get; set; }
		public int Count { get; set; }
		public string DefaultImage { get; set; }
		public int Rows { get; set; }
		public int Columns { get; set; }
		public ImageButton[][] img;
		public string[][] PathInfo;
	}
	public class CPathInfo
	{
		public CPathInfo()
		{ 
		}
	}
	public class CNode
	{
		public CNode()
		{ 
		}
		public ImageButton Button { get; set; }
		public string ImageUrl { get; set; }
		public string DefaultUrl { get; set; }
		public void Load()
		{
			this.Button.ImageUrl = ImageUrl;
		}
		public void Reset()
		{
			this.Button.ImageUrl = DefaultUrl;
		}
	}
}
