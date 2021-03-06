﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace twozerofoureight
{
    public partial class TwoZeroFourEightView : Form, View
    {
        Model model;
        Controller controller;
       
        public TwoZeroFourEightView()
        {
            InitializeComponent();
            model = new TwoZeroFourEightModel();
            model.AttachObserver(this);
            controller = new TwoZeroFourEightController();
            controller.AddModel(model);
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);

            //kpeh = new KeyPressEventHandler(key_Press);
           // this.KeyPress += kpeh; //this works only when the contro (form) has focus

            keh = new KeyEventHandler(key_Down);
             this.KeyDown += keh;  //this works only when the control (form) has focus

           // this.KeyPress += new KeyPressEventHandler(key_Press); //create object

        }
       // private KeyPressEventHandler kpeh;
        private KeyEventHandler keh;

       // protected void key_Press(object sneder , EventArgs e)
       // {
            
       // }
        //protected void key_Down(object sender , EventArgs e)
       // {

      //  }
        //the own method to bevexcuted when the event occurs.
        private void key_Press(object sender, KeyPressEventArgs e)
        {

            if(e.KeyChar == 'w')
            {
                controller.ActionPerformed(TwoZeroFourEightController.UP);
            }
            //check if allow key up is pressed then call something to perform UP
            //
        }
        private void key_Down(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Right:
                case Keys.D:
                    controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
                    break;
                case Keys.Left:
                case Keys.A:
                    controller.ActionPerformed(TwoZeroFourEightController.LEFT);
                    break;
                case Keys.Up:
                case Keys.W:
                    controller.ActionPerformed(TwoZeroFourEightController.UP);
                    break;
                case Keys.Down:
                case Keys.S:
                    controller.ActionPerformed(TwoZeroFourEightController.DOWN);
                    break;

            }
       /* if(e.KeyData == Keys.Right)
            {
                controller.ActionPerformed(TwoZeroFourEightController.RIGHT);

            }
            else if(e.KeyData == Keys.Down)
            {
                controller.ActionPerformed(TwoZeroFourEightController.DOWN);
            }
            else if (e.KeyData == Keys.Left)
            {
                controller.ActionPerformed(TwoZeroFourEightController.LEFT);
            }
            else if (e.KeyData == Keys.Up)
            {
                controller.ActionPerformed(TwoZeroFourEightController.UP);
            }

    */

            //check if allow key up is down then call something to perform UP
        }

        public void Notify(Model m)
        {
            UpdateBoard(((TwoZeroFourEightModel) m).GetBoard()); //call medtod // m model  //casting
            UpdateScore(((TwoZeroFourEightModel)m).GetScore());
            UpdateGameStatus(((TwoZeroFourEightModel)m).IsGameover(((TwoZeroFourEightModel)m).GetBoard())); //add new on board
        }
        private void UpdateGameStatus(bool b)
        {
            //if(true) , hide "this  form" and show "gameover form "
            if(b == true)
            {
                lblScore.Text = "Gameover";  //print on text score
            }
        }

        private void UpdateScore(int i)
        {
            lblScore.Text = i.ToString();
        }

        private void UpdateTile(Label l, int i)
        {
            if (i != 0)
            {
                l.Text = Convert.ToString(i);
            } else {
                l.Text = "";
            }
            switch (i)
            {
                case 0:
                    l.BackColor = Color.Pink;
                    break;
                case 2:
                    l.BackColor = Color.GreenYellow;
                    break;
                case 4:
                    l.BackColor = Color.Orange;
                    break;
                case 8:
                    l.BackColor = Color.Red;
                    break;
                default:
                    l.BackColor = Color.Green;
                    break;
            }
        }
        private void UpdateBoard(int[,] board)
        {
            UpdateTile(lbl00,board[0, 0]);
            UpdateTile(lbl01,board[0, 1]);
            UpdateTile(lbl02,board[0, 2]);
            UpdateTile(lbl03,board[0, 3]);
            UpdateTile(lbl10,board[1, 0]);
            UpdateTile(lbl11,board[1, 1]);
            UpdateTile(lbl12,board[1, 2]);
            UpdateTile(lbl13,board[1, 3]);
            UpdateTile(lbl20,board[2, 0]);
            UpdateTile(lbl21,board[2, 1]);
            UpdateTile(lbl22,board[2, 2]);
            UpdateTile(lbl23,board[2, 3]);
            UpdateTile(lbl30,board[3, 0]);
            UpdateTile(lbl31,board[3, 1]);
            UpdateTile(lbl32,board[3, 2]);
            UpdateTile(lbl33,board[3, 3]);
        }



        private void btnLeft_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.LEFT);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.RIGHT);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.UP);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            controller.ActionPerformed(TwoZeroFourEightController.DOWN);
        }


    }
}
