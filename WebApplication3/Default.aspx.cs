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
					img[i][j].Click += new ImageClickEventHandler(_Default_Click);
				}
			}
		}

		void _Default_Click(object sender, ImageClickEventArgs e)
		{
			((ImageButton)sender).ImageUrl = "one.png";
			((TableCell)((ImageButton)sender).Parent).BorderColor = Color.Red;
		}
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
}
