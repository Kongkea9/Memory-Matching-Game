using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MemoryMatchingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Button> cards;
        private List<int> flippedCards;
        List<int> imageLists;
        List<int> unMatchingCards;
        private int row;
        private int column;
        private string category;
        private int move;
        private int matchingCard;
        private int blueMatching;
        private int redMatching;
        private int numberOfPlayer;
        private int playerTurn;
        private int paushClick ;
        public MainWindow(int numberOfPlayer, string category, int row, int column)
        {
            InitializeComponent();
            Timer();
            this.numberOfPlayer = numberOfPlayer;
            this.category = category;
            this.row = row;
            this.column = column;
            move = 0;
            matchingCard = 0;  
            blueMatching = 0;
            redMatching = 0;
            playerTurn = 0;
            paushClick =0;
            tbMove.Text = move.ToString();
            cards = new List<Button>();
            flippedCards = new List<int>();
            unMatchingCards = new List<int>();
            GetUnMatchingCards();
            CreateGameGrid(row, column,numberOfPlayer);

            if (numberOfPlayer == 2)
            {
               
                playerScore(blueMatching, redMatching, playerTurn);

            }
            GetImageIndex();
            

        }


        private DispatcherTimer timer;
        private int elapsedTime;
        
        private void Timer()
        {
            elapsedTime = 0; 

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); 
            timer.Tick += Timer_Tick;
            timer.Start();
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            elapsedTime++;

            int min = elapsedTime / 60;
            int sec = elapsedTime % 60;
            tbTime.Text = $"{min:D2} : {sec:D2}";
        }

        private void RestartTimer()
        {
            timer.Stop(); 
            elapsedTime = 0; 
            tbTime.Text = "00 : 00"; 
            
        }
        private void GetUnMatchingCards()
        {
            for (int i = 0; i < row * column; i++)
            {
                unMatchingCards.Add(i);
            }
        }


        private void Move(int move)
        {
            tbMove.Text = move.ToString();
        }
        private void CreateGameGrid(int row, int column, int numberOfPlayer)
        {
            GameGrid.RowDefinitions.Clear();
            GameGrid.ColumnDefinitions.Clear();
            cards.Clear();
            flippedCards.Clear();
            GameGrid.Children.Clear();

            ControlTemplate roundedButtonTemplate = CreateRoundedButtonTemplate();

            for (int i = 0; i < row; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < column; i++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }



            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {

                    Button card = new Button
                    {
                        Content = null,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        Template = roundedButtonTemplate,
                        BorderThickness = new Thickness(3),
                        Margin = new Thickness(3),
                        BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00BFFF")),

                    };


                    ImageBrush buttonBackground = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri($"pack://application:,,,/CoverImage/CardCover.png")),
                        Stretch = Stretch.Fill 
                    };
                    card.Background = buttonBackground;

                    card.Effect = new DropShadowEffect
                    {
                        Color = (Color)ColorConverter.ConvertFromString("#1B262C"),
                        BlurRadius = 25,
                        ShadowDepth = 5
                    };

                    if(numberOfPlayer==1)
                        card.Click += Card_Click1;
                    if(numberOfPlayer==2)
                        card.Click += Card_Click2;

                    Grid.SetRow(card, i);
                    Grid.SetColumn(card, j);
                    GameGrid.Children.Add(card);
                    cards.Add(card);

                }

            }

        }

        private void playerScore(int blueMatching, int redMatching, int playerTurn)
        {
            PlayerScore.Children.Clear();         
            bool isBlueTurn = playerTurn % 2 == 0;

            TextBlock matchingCard1 = new TextBlock
            {
                Text = "Blue : " + blueMatching.ToString(),
                FontSize = 15,
                Foreground = Brushes.WhiteSmoke,
                FontStyle = FontStyles.Italic,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            Border border = new Border
            {
                BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                Background = new SolidColorBrush(isBlueTurn
                    ? (Color)ColorConverter.ConvertFromString("#1272EB") // Highlight for Player 1 turn
                    : (Color)ColorConverter.ConvertFromString("#B0D3FD")), // Dim for Player 2 turn
                BorderThickness = new Thickness(3),
                CornerRadius = new CornerRadius(18),
                Padding = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 60,
                Width = 150,
                Child = matchingCard1
            };

            TextBlock matchingCard2 = new TextBlock
            {
                Text = "Red : " + redMatching.ToString(),
                FontSize = 15,
                Foreground = Brushes.WhiteSmoke,
                FontStyle = FontStyles.Italic,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            Border border1 = new Border
            {
                BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF")),
                Background = new SolidColorBrush(!isBlueTurn
                    ? (Color)ColorConverter.ConvertFromString("#F04042") // Highlight for Player 2 turn
                    : (Color)ColorConverter.ConvertFromString("#F9ACAC")), // Dim for Player 1 turn
                BorderThickness = new Thickness(3),
                CornerRadius = new CornerRadius(18),
                Padding = new Thickness(5),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Height = 60,
                Width = 150,
                Child = matchingCard2
            };

            border.Effect = new DropShadowEffect
            {
                Color = (Color)ColorConverter.ConvertFromString("#B6B3B3"),
                BlurRadius = 5,
                ShadowDepth = 3
            };
            border1.Effect = new DropShadowEffect
            {
                Color = (Color)ColorConverter.ConvertFromString("#B6B3B3"),
                BlurRadius = 5,
                ShadowDepth = 3
            };



            Grid.SetColumn(border, 0);
            Grid.SetColumn(border1, 1);

            PlayerScore.Children.Add(border);
            PlayerScore.Children.Add(border1);

        }

       
        private void UpdateTurnIndicator(int playerTurn)
        {
            playerScore(blueMatching, redMatching, playerTurn);
        }

        private ControlTemplate CreateRoundedButtonTemplate()
        {
            ControlTemplate template = new ControlTemplate(typeof(Button));
            FrameworkElementFactory border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(15));
            border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(Button.BackgroundProperty));
            border.SetValue(Border.BorderBrushProperty, new TemplateBindingExtension(Button.BorderBrushProperty));
            border.SetValue(Border.BorderThicknessProperty, new TemplateBindingExtension(Button.BorderThicknessProperty));

            FrameworkElementFactory contentPresenter = new FrameworkElementFactory(typeof(ContentPresenter));
            contentPresenter.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            contentPresenter.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            contentPresenter.SetValue(TextElement.FontSizeProperty, new TemplateBindingExtension(Button.FontSizeProperty));
            contentPresenter.SetValue(TextElement.FontStyleProperty, new TemplateBindingExtension(Button.FontStyleProperty));
            contentPresenter.SetValue(TextElement.FontWeightProperty, new TemplateBindingExtension(Button.FontWeightProperty));
            contentPresenter.SetValue(TextElement.ForegroundProperty, new TemplateBindingExtension(Button.ForegroundProperty));
            border.AppendChild(contentPresenter);
            template.VisualTree = border;

            return template;
        }


        private void GetImageIndex()
        {
            Random random = new Random();
            HashSet<int> imagesIndexs = new HashSet<int>();
            List<int> imagesIndexForCards = new List<int>();
            imageLists = new List<int>();
            int numberOfImage = (row * column) / 2;
            while (imagesIndexs.Count < numberOfImage)
            {
                int imageIndex = random.Next(1, 26);
                imagesIndexs.Add(imageIndex);
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (int j in imagesIndexs)
                {
                    imagesIndexForCards.Add(j);
                }
            }
            int imagesSize = imagesIndexForCards.Count;

            for (int i = 0; i < imagesSize; i++)
            {
                int imagesIndexForCard = random.Next(imagesIndexForCards.Count);
                int image = imagesIndexForCards[imagesIndexForCard];
                imageLists.Add(image);
                imagesIndexForCards.RemoveAt(imagesIndexForCard);
            }
        }


        private void IsDisabledCard()
        {
            foreach (var card in cards)
            {
                card.IsEnabled = false;
            }
        }
        private void IsEnabledCard()
        {
            for (int i = 0; i < unMatchingCards.Count; i++)
            {
                cards[unMatchingCards[i]].IsEnabled = true;
            }
        }


        private void Card_Click1(object sender, RoutedEventArgs e)
        {
            move++;
            Move(move);
            
            Button clickedCard = (Button)sender;
            int cardIndex = cards.IndexOf(clickedCard);
            flippedCards.Add(cardIndex);

            int selectedImage = imageLists[cardIndex];
            cards[cardIndex].IsEnabled = false;

            clickedCard.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#96BDEF"));

            clickedCard.Content = new Image
            {
                Source = new BitmapImage(new Uri($"pack://application:,,,/{category}/{selectedImage}.png")),
                Margin = new Thickness(5),
            };

            if (flippedCards.Count == 2)
            {
                int cardIndex1 = flippedCards[0];
                int cardIndex2 = flippedCards[1];

                if (imageLists[cardIndex1] == imageLists[cardIndex2])
                {
                    matchingCard++;
                    unMatchingCards.Remove(cardIndex1);
                    unMatchingCards.Remove(cardIndex2);
                    IsDisabledCard();

                    Dispatcher.InvokeAsync(async () =>
                    {
                        await System.Threading.Tasks.Task.Delay(500);
                        
                        cards[cardIndex1].IsEnabled = false;
                        cards[cardIndex2].IsEnabled = false;
                        cards[cardIndex1].Content = null;
                        cards[cardIndex2].Content = null;
                        cards[cardIndex1].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1E3FA"));
                        cards[cardIndex2].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1E3FA"));

                        flippedCards.Clear();
                        IsEnabledCard();


                    });
                }
                else
                {
                    IsDisabledCard();

                    Dispatcher.InvokeAsync(async () =>
                    {
                        await System.Threading.Tasks.Task.Delay(500);

                        ImageBrush buttonBackground = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri($"pack://application:,,,/CoverImage/CardCover.png")),
                            Stretch = Stretch.Fill
                        };
                        cards[cardIndex1].IsEnabled = true;
                        cards[cardIndex2].IsEnabled = true;
                        cards[cardIndex1].Background = buttonBackground;
                        cards[cardIndex2].Background = buttonBackground;
                        cards[cardIndex1].Content = null;
                        cards[cardIndex2].Content = null;

                        flippedCards.Clear();
                        IsEnabledCard();


                    });
                }
            }

            if (matchingCard == imageLists.Count / 2)
            {
                timer.Stop();
                Dispatcher.InvokeAsync(async () =>
                {
                    await System.Threading.Tasks.Task.Delay(700);
                    frm1PlayerResult frm1PlayerResult = new frm1PlayerResult(numberOfPlayer, category, row, column, tbTime.Text, move);
                    frm1PlayerResult.Show();
                    this.Close();

                });
            }

        }

        private void Card_Click2(object sender, RoutedEventArgs e)
        {
            move++;
            Move(move);
            bool isBlueTurn = playerTurn % 2 == 0;

            Button clickedCard = (Button)sender;
            int cardIndex = cards.IndexOf(clickedCard);
            flippedCards.Add(cardIndex);

            int selectedImage = imageLists[cardIndex];
            cards[cardIndex].IsEnabled = false;

            clickedCard.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#96BDEF"));

            clickedCard.Content = new Image
            {
                Source = new BitmapImage(new Uri($"pack://application:,,,/{category}/{selectedImage}.png")),
                Margin = new Thickness(5),
            };

            if (flippedCards.Count == 2)
            {
                int cardIndex1 = flippedCards[0];
                int cardIndex2 = flippedCards[1];

                if (imageLists[cardIndex1] == imageLists[cardIndex2])
                {
                    matchingCard++;
                    unMatchingCards.Remove(cardIndex1);
                    unMatchingCards.Remove(cardIndex2);
                    if (isBlueTurn)
                        blueMatching++;
                    else
                        redMatching++;


                    IsDisabledCard();

                    Dispatcher.InvokeAsync(async () =>
                    {
                        await System.Threading.Tasks.Task.Delay(500);
                        cards[cardIndex1].IsEnabled = false;
                        cards[cardIndex2].IsEnabled = false;
                        cards[cardIndex1].Content = null;
                        cards[cardIndex2].Content = null;
                        cards[cardIndex1].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1E3FA"));
                        cards[cardIndex2].Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D1E3FA"));

                        flippedCards.Clear();
                        UpdateTurnIndicator(playerTurn);
                        IsEnabledCard();

                    });
                }
                else
                {
                    IsDisabledCard();

                    Dispatcher.InvokeAsync(async () =>
                    {
                        await System.Threading.Tasks.Task.Delay(500);

                        ImageBrush buttonBackground = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri($"pack://application:,,,/CoverImage/CardCover.png")),
                            Stretch = Stretch.Fill
                        };
                        cards[cardIndex1].IsEnabled = true;
                        cards[cardIndex2].IsEnabled = true;
                        cards[cardIndex1].Background = buttonBackground;
                        cards[cardIndex2].Background = buttonBackground;
                        cards[cardIndex1].Content = null;
                        cards[cardIndex2].Content = null;


                        flippedCards.Clear();

                        playerTurn++;
                        UpdateTurnIndicator(playerTurn);
                        IsEnabledCard();

                    });
                }
            }

            if (matchingCard == imageLists.Count / 2)
            {
                timer.Stop();
                Dispatcher.InvokeAsync(async () =>
                {
                    await System.Threading.Tasks.Task.Delay(700);
                    frm2PlayersResult frm2PlayersResult = new frm2PlayersResult(numberOfPlayer, category, row, column, tbTime.Text, move, blueMatching, redMatching);
                    frm2PlayersResult.Show();
                    this.Close();

                });
            }
        
        }

        private void btnRestart_Click(object sender, RoutedEventArgs e)
        {
                move = 0;
                Move(move);
                matchingCard = 0;
                RestartTimer();
                Timer();
                CreateGameGrid(row, column, numberOfPlayer);
                GetImageIndex();
                playerTurn = 0;
                unMatchingCards.Clear();
                GetUnMatchingCards();
                //Paush
                paushClick = 0;
                btnPaushIcon.Source = new BitmapImage(new Uri("pack://application:,,,/ButtonIcon/Paush.png"));
                IsEnabledCard();



            if (numberOfPlayer == 2)
            {
               
                blueMatching = 0;
                redMatching = 0;
                playerTurn = 0;
                flippedCards.Clear();
                playerScore(blueMatching, redMatching, playerTurn);

            }

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            frmCover frmCover = new frmCover();
            frmCover.Show();
            this.Close();
        }
        
        private void btnPaush_Click(object sender, RoutedEventArgs e)
        {
            
            if (paushClick == 0)
            {
                timer.Stop();
                btnPaushIcon.Source = new BitmapImage(new Uri("pack://application:,,,/ButtonIcon/Play.png"));
   
                paushClick += 1;
                IsDisabledCard();
                
            }
            else if (paushClick == 1)
            {
                timer.Start();
                btnPaushIcon.Source = new BitmapImage(new Uri("pack://application:,,,/ButtonIcon/Paush.png"));
                IsEnabledCard();
                paushClick = 0;
            }
            

        }

        
    }
}
