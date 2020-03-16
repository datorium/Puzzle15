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
        Random Rand = new Random();
        int moves = 0;
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
            }
            button16.Text = "";
            UpdateMovesLabel();
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
            int oldLeft = tile.Left;
            int oldTop = tile.Top;
            tile.Left = button16.Left;
            tile.Top = button16.Top;
            button16.Left = oldLeft;
            button16.Top = oldTop;
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
    }
}
