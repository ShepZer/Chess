using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess{
    public partial class Form1 : Form{

        public int[,] map = new int[8, 8]{ //шахматнная доска
            {15,13,14,19,18,14,13,15},
            {11,11,11,11,11,11,11,11},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0},
            {21,21,21,21,21,21,21,21},
            {25,23,24,29,28,24,23,25},
        };

        public int[,] firstStep = new int[2, 8]{//позволяет отслеживать, какая пешка уже сошла со своего места (не разрешает ходит на две клетки)
            {1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1},
        };

        public Button[,] butts = new Button[8, 8];//массив кнопок (чтобы шахматная доска было кнопками)

        public int currPlayer;//текущий игрок

        public Button prevButton;

        public bool isMoveing = false;

        public Image chessSprites;

        public Form1(){
            InitializeComponent();

            chessSprites = new Bitmap("chess.png");//отрисофка шахматных фигурок

            Init();
        }

        public void Init(){

            map = new int[8, 8]{
                {15,13,14,18,19,14,13,15},
                {11,11,11,11,11,11,11,11},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0},
                {21,21,21,21,21,21,21,21},
                {25,23,24,28,29,24,23,25},
            };

            currPlayer = 1;

            CreateMap();
        }

        public void CreateMap(){//создание поля на форме

            for (int i = 0; i < 8; i++){
                for (int j = 0; j < 8; j++){

                    butts[i, j] = new Button();

                    Button butt = new Button();
                    butt.Size = new Size(50, 50);
                    butt.Location = new Point(j * 50, i * 50);

                    switch (map[i, j] / 10){
                        case 2://белая
                            switch (map[i, j] % 10){
                                case 1://пешка
                                    Image part = new Bitmap(50, 50);
                                    Graphics grap = Graphics.FromImage(part);
                                    grap.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 750, 150, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part;
                                    break;
                                case 3://конь
                                    Image part1 = new Bitmap(50, 50);
                                    Graphics grap1 = Graphics.FromImage(part1);
                                    grap1.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 450, 150, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part1;
                                    break;
                                case 4://слон
                                    Image part2 = new Bitmap(50, 50);
                                    Graphics grap2 = Graphics.FromImage(part2);
                                    grap2.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 300, 150, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part2;
                                    break;
                                case 5://ферзь
                                    Image part3 = new Bitmap(50, 50);
                                    Graphics grap3 = Graphics.FromImage(part3);
                                    grap3.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 600, 150, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part3;
                                    break;
                                case 9://кинг
                                    Image part4 = new Bitmap(50, 50);
                                    Graphics grap4 = Graphics.FromImage(part4);
                                    grap4.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150, 150, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part4;
                                    break;
                                case 8://дева
                                    Image part5 = new Bitmap(50, 50);
                                    Graphics grap5 = Graphics.FromImage(part5);
                                    grap5.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0, 150, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part5;
                                    break;
                            }
                            break;
                        case 1://черная
                            switch (map[i, j] % 10){
                                case 1://пешка
                                    Image part = new Bitmap(50, 50);
                                    Graphics grap = Graphics.FromImage(part);
                                    grap.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 750, 0, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part;
                                    break;
                                case 3://конь
                                    Image part1 = new Bitmap(50, 50);
                                    Graphics grap1 = Graphics.FromImage(part1);
                                    grap1.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 450, 0, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part1;
                                    break;
                                case 4://слон
                                    Image part2 = new Bitmap(50, 50);
                                    Graphics grap2 = Graphics.FromImage(part2);
                                    grap2.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 300, 0, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part2;
                                    break;
                                case 5://ферзь
                                    Image part3 = new Bitmap(50, 50);
                                    Graphics grap3 = Graphics.FromImage(part3);
                                    grap3.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 600, 0, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part3;
                                    break;
                                case 9://кинг
                                    Image part4 = new Bitmap(50, 50);
                                    Graphics grap4 = Graphics.FromImage(part4);
                                    grap4.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 150, 0, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part4;
                                    break;
                                case 8://дева
                                    Image part5 = new Bitmap(50, 50);
                                    Graphics grap5 = Graphics.FromImage(part5);
                                    grap5.DrawImage(chessSprites, new Rectangle(0, 0, 50, 50), 0, 0, 150, 150, GraphicsUnit.Pixel);
                                    butt.BackgroundImage = part5;
                                    break;
                            }
                            break;
                    }
                    butt.BackColor = Color.White;
                    butt.Click += new EventHandler(OnFigurePress);
                    this.Controls.Add(butt);

                    butts[i, j] = butt;
                }
            }
        }
        public void OnFigurePress(object sender, EventArgs e){//отслеживает нажатие на кнопку

            if (prevButton != null){
                prevButton.BackColor = Color.White;
            }

            Button pressedButton = sender as Button;
            
            if (map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] != 0 && map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] / 10 == currPlayer){
                
                CloseSteps();
                //pressedButton.BackColor = Color.Red;
                DeactivateAllButtons();
                pressedButton.Enabled = false;
                ShowSteps(pressedButton.Location.Y / 50, pressedButton.Location.X / 50, map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50]);

                if (isMoveing){
                    CloseSteps();
                    pressedButton.BackColor = Color.White;
                    ActivateAllButtons();
                    isMoveing = false;
                }
                else{
                    isMoveing = true;
                }
            }
            else{
                if (isMoveing){

                    int temp = map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50];

                    map[pressedButton.Location.Y / 50, pressedButton.Location.X / 50] = map[prevButton.Location.Y / 50, prevButton.Location.X / 50];
                    map[prevButton.Location.Y / 50, prevButton.Location.X / 50] = temp;

                    pressedButton.BackgroundImage = prevButton.BackgroundImage;
                    prevButton.BackgroundImage = null;
                    map[prevButton.Location.Y / 50, prevButton.Location.X / 50] = 0;
                    isMoveing = false;

                    CloseSteps();
                    ActivateAllButtons();
                    SwitchPlayer();
                }
            }
            prevButton = pressedButton;

            if (TestEnd() == false){
                MessageBox.Show("END!!!");
            }
        }

        public void SwitchPlayer(){//смена игрока
            if (currPlayer == 1){
                currPlayer = 2;
            }
            else{
                currPlayer = 1;
            }
        }
        private void button1_Click(object sender, EventArgs e){//новая игра
            this.Controls.Clear();
            Init();
        }

        public void ShowSteps(int IcurrFigure, int JcurrFigure, int currFigure){//показывает как может ходить фигура
            int dir = currPlayer == 1 ? 1 : -1;
            switch (currFigure % 10){
                case 1://пешка!!! Тут при отмене хода пешкой не разрешает сходить на две клетки
                    if (firstStep[currPlayer - 1, JcurrFigure] == 1){
                        butts[IcurrFigure + 1 * dir, JcurrFigure].BackColor = Color.Yellow;
                        butts[IcurrFigure + 1 * dir, JcurrFigure].Enabled = true;
                        dir = 2 * dir;
                        firstStep[currPlayer - 1, JcurrFigure] = 0;
                    }
                    if (InsideBorder(IcurrFigure + 1 * dir, JcurrFigure)){
                        if (map[IcurrFigure + 1 * dir, JcurrFigure] == 0){
                            butts[IcurrFigure + 1 * dir, JcurrFigure].BackColor = Color.Yellow;
                            butts[IcurrFigure + 1 * dir, JcurrFigure].Enabled = true;
                        }
                    }
                    if (InsideBorder(IcurrFigure + 1 * dir, JcurrFigure + 1)){
                        if (map[IcurrFigure + 1 * dir, JcurrFigure + 1] != 0 && map[IcurrFigure + 1 * dir, JcurrFigure + 1] / 10 != currPlayer){
                            butts[IcurrFigure + 1 * dir, JcurrFigure + 1].BackColor = Color.Yellow;
                            butts[IcurrFigure + 1 * dir, JcurrFigure + 1].Enabled = true;
                        }
                    }
                    if (InsideBorder(IcurrFigure + 1 * dir, JcurrFigure - 1)){
                        if (map[IcurrFigure + 1 * dir, JcurrFigure - 1] != 0 && map[IcurrFigure + 1 * dir, JcurrFigure - 1] / 10 != currPlayer){
                            butts[IcurrFigure + 1 * dir, JcurrFigure - 1].BackColor = Color.Yellow;
                            butts[IcurrFigure + 1 * dir, JcurrFigure - 1].Enabled = true;
                        }
                    }
                    break;
                case 5://ладья
                    ShowVerticalHorizontal(IcurrFigure, JcurrFigure);
                    break;
                case 4://cлон
                    ShowDiagonal(IcurrFigure, JcurrFigure);
                    break;
                case 9://ферзь
                    ShowVerticalHorizontal(IcurrFigure, JcurrFigure);
                    ShowDiagonal(IcurrFigure, JcurrFigure);
                    break;
                case 8://КОРОЛЬ
                    ShowVerticalHorizontal(IcurrFigure, JcurrFigure, true);
                    ShowDiagonal(IcurrFigure, JcurrFigure, true);
                    break;
                case 3://конь
                    ShowHorseSteps(IcurrFigure, JcurrFigure);
                    break;
            }
        }

        public void ShowHorseSteps(int IcurrFigure, int JcurrFigure){//конь
            if (InsideBorder(IcurrFigure - 2, JcurrFigure + 1)){
                DeterminePath(IcurrFigure - 2, JcurrFigure + 1);
            }
            if (InsideBorder(IcurrFigure - 2, JcurrFigure - 1)){
                DeterminePath(IcurrFigure - 2, JcurrFigure - 1);
            }
            if (InsideBorder(IcurrFigure + 2, JcurrFigure + 1)){
                DeterminePath(IcurrFigure + 2, JcurrFigure + 1);
            }
            if (InsideBorder(IcurrFigure + 2, JcurrFigure - 1)){
                DeterminePath(IcurrFigure + 2, JcurrFigure - 1);
            }
            if (InsideBorder(IcurrFigure - 1, JcurrFigure + 2)){
                DeterminePath(IcurrFigure - 1, JcurrFigure + 2);
            }
            if (InsideBorder(IcurrFigure + 1, JcurrFigure + 2)){
                DeterminePath(IcurrFigure + 1, JcurrFigure + 2);
            }
            if (InsideBorder(IcurrFigure - 1, JcurrFigure - 2)){
                DeterminePath(IcurrFigure - 1, JcurrFigure - 2);
            }
            if (InsideBorder(IcurrFigure + 1, JcurrFigure - 2)){
                DeterminePath(IcurrFigure + 1, JcurrFigure - 2);
            }
        }

        public void DeactivateAllButtons(){//отлючить возможность нажатия на кнопки
            for (int i = 0; i < 8; i++){
                for (int j = 0; j < 8; j++){
                    butts[i, j].Enabled = false;
                }
            }
        }

        public void ActivateAllButtons(){//активировать кнопки
            for (int i = 0; i < 8; i++){
                for (int j = 0; j < 8; j++){
                    butts[i, j].Enabled = true;
                }
            }
        }

        public void ShowDiagonal(int IcurrFigure, int JcurrFigure, bool isOneStep = false){
            int j = JcurrFigure + 1;
            for (int i = IcurrFigure - 1; i >= 0; i--){
                if (InsideBorder(i, j)){
                    if (!DeterminePath(i, j)){
                        break;
                    }
                }
                if (j < 7){
                    j++;
                }
                else{
                    break;
                }

                if (isOneStep){
                    break;
                }
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure - 1; i >= 0; i--){
                if (InsideBorder(i, j)){
                    if (!DeterminePath(i, j)){
                        break;
                    }
                }
                if (j > 0){
                    j--;
                }
                else{
                    break;
                }

                if (isOneStep){
                    break;
                }
            }

            j = JcurrFigure - 1;
            for (int i = IcurrFigure + 1; i < 8; i++){
                if (InsideBorder(i, j)){
                    if (!DeterminePath(i, j)){
                        break;
                    }
                }
                if (j > 0){
                    j--;
                }
                else{
                    break;
                }

                if (isOneStep){
                    break;
                }
            }

            j = JcurrFigure + 1;
            for (int i = IcurrFigure + 1; i < 8; i++){
                if (InsideBorder(i, j)){
                    if (!DeterminePath(i, j)){
                        break;
                    }
                }
                if (j < 7){
                    j++;
                }
                else{
                    break;
                }

                if (isOneStep){
                    break;
                }
            }
        }

        public void ShowVerticalHorizontal(int IcurrFigure, int JcurrFigure, bool isOneStep = false){
            for (int i = IcurrFigure + 1; i < 8; i++){
                if (InsideBorder(i, JcurrFigure)){
                    if (!DeterminePath(i, JcurrFigure)){
                        break;
                    }
                }
                if (isOneStep){
                    break;
                }
            }
            for (int i = IcurrFigure - 1; i >= 0; i--){
                if (InsideBorder(i, JcurrFigure)){
                    if (!DeterminePath(i, JcurrFigure)){
                        break;
                    }
                }
                if (isOneStep)
                {
                    break;
                }
            }
            for (int j = JcurrFigure + 1; j < 8; j++){
                if (InsideBorder(IcurrFigure, j)){
                    if (!DeterminePath(IcurrFigure, j)){
                        break;
                    }
                }
                if (isOneStep){
                    break;
                }
            }
            for (int j = JcurrFigure - 1; j >= 0; j--){
                if (InsideBorder(IcurrFigure, j)){
                    if (!DeterminePath(IcurrFigure, j)){
                        break;
                    }
                }
                if (isOneStep){
                    break;
                }
            }
        }

        public bool DeterminePath(int IcurrFigure, int j){
            if (map[IcurrFigure, j] == 0){
                butts[IcurrFigure, j].BackColor = Color.Yellow;
                butts[IcurrFigure, j].Enabled = true;
            }
            else{
                if (map[IcurrFigure, j] / 10 != currPlayer){
                    butts[IcurrFigure, j].BackColor = Color.Yellow;
                    butts[IcurrFigure, j].Enabled = true;
                }
                return false;
            }
            return true;
        }

        public bool InsideBorder(int ti, int tj){
            if (ti >= 8 || tj >= 8 || ti < 0 || tj < 0){
                return false;
            }
            return true;
        }

        public void CloseSteps(){
            for (int i = 0; i < 8; i++){
                for (int j = 0; j < 8; j++){
                    butts[i, j].BackColor = Color.White;
                }
            }
        }

        public bool TestEnd(){//проверка конца игры
            for (int i = 0; i < 8; i++){
                for (int j = 0; j < 8; j++){
                    if (map[i, j] % 10 == 8 && map[i, j] / 10 == currPlayer){
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
