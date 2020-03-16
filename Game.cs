using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle15_SAT1100
{
    public partial class Game : Form
    {
        int moves = 0;
        Random Rand = new Random();
        Color tileBackColor;        
        Point[] locations = new Point[15];
        public Game()
        {
            InitializeComponent();
            InitilalizeGame();
            ShuffleTiles();
        }

        private void InitilalizeGame()
        {
            string tileName;
            Button tile;

            for(int i = 1; i <= 15; i++) 
            {
                tileName = "button" + i.ToString();
                tile = (Button)this.Controls[tileName];             
                tile.Text = i.ToString();
                locations[i - 1] = tile.Location;
            }
            button16.Text = "";
            UpdateMovesLabel();
        }

        private void CheckForWin()
        {
            bool win = true;
            string tileName;
            Button tile;

            for (int i = 1; i <= 15; i++)
            {
                tileName = "button" + i.ToString();
                tile = (Button)this.Controls[tileName];
                win = win & (tile.Location == locations[i - 1]);
            }

            if (win)
            {
                GameWin();
            }
        }

        private void GameWin()
        {
            MessageBox.Show("You won!");
        }

        private void UpdateMovesLabel()
        {
            MovesLabel.Text = "Moves: " + moves.ToString();
        }

        private void TileClick(object sender, EventArgs e)
        {
            Button tile = (Button)sender;
            if (TileClose(tile))
            {
                SwitchTiles(tile);
                moves++; //moves += 1;
                UpdateMovesLabel();
            }            
        }

        private void SwitchTiles(Button tile)
        {
            Point oldLocation = tile.Location;
            tile.Location = button16.Location;
            button16.Location = oldLocation;
            
            //int oldLeft = tile.Left;
            //int oldTop = tile.Top;
            //tile.Left = button16.Left;
            //tile.Top = button16.Top;
            //button16.Left = oldLeft;
            //button16.Top = oldTop;
        }

        private void ShuffleTiles()
        {
            string tileName;
            Button tile;
            for(int i = 1; i <= 100; i++)
            {
                tileName = "button" + Rand.Next(1, 16).ToString();
                tile = (Button)this.Controls[tileName];
                SwitchTiles(tile);
            }
            moves = 0;
            UpdateMovesLabel();
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            ShuffleTiles();
        }

        private bool TileClose(Button tile)
        {
            int xTile = tile.Location.X;
            int yTile = tile.Location.Y;
            int xEmptyTile = button16.Location.X;
            int yEmptyTile = button16.Location.Y;
            int a = xEmptyTile - xTile;
            int b = yEmptyTile - yTile;
            double c = Math.Sqrt(Math.Pow(a,2) + Math.Pow(b,2));
            return c < 105;
        }

        private void TileMouseEnter(object sender, EventArgs e)
        {            
            Button tile = (Button)sender;
            tileBackColor = tile.BackColor;
            if (TileClose(tile))
            {
                tile.BackColor = Color.Green;
            }
            else
            {
                tile.BackColor = Color.Red;
            }
        }

        private void TileMouseLeave(object sender, EventArgs e)
        {
            Button tile = (Button)sender;
            tile.BackColor = tileBackColor;
        }
    }
}
