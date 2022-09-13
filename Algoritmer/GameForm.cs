namespace Algoritmer
{
    public partial class GameForm : Form
    {
		public enum CardType
		{
			Hearts,
			Diamonds,
			Spades,
			Clubs,
		}
	    private const int CardCount = 13;
	    private const int DeckSize = 52;

	    private readonly Deck _mainDeck;
	    private readonly Graphics _graphics;
	    private readonly Pen _cardPen;

	    private static readonly Random Random = new Random();

	    public GameForm() // effectively start
        {
	        InitializeComponent();

	        _graphics = CreateGraphics();
	        _cardPen = new Pen(Color.Red, 5);

	        _mainDeck = new Deck();
	        _mainDeck.Shuffle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
			BackColor = Color.Black;

			_mainDeck.Draw();
        }


        private class Deck
        {
	        public readonly List<Card> Cards;

	        public Deck() // fresh deck of cards
	        {
		        Cards = new List<Card>();
		        const int amountOfCardsPerType = DeckSize / CardCount;
		        for (int cardNumberIndex = 0; cardNumberIndex < CardCount; cardNumberIndex++)
		        {
			        for (int type = 0; type < amountOfCardsPerType; type++)
			        {
				        Cards.Add(new Card(cardNumberIndex));
			        }
		        }
	        }

	        // public Deck(List<Card> cards) // Construction from cards
	        // {
		       //  Cards = cards;
	        // } // note: probably shouldnt want this, logic-wise?

	        public void Shuffle()
	        {
		        for (int i = 0; i < DeckSize; i++)
		        {
			        int randomIndex = Random.Next(DeckSize);
			        // swap card index with random card index
			        (Cards[i], Cards[randomIndex]) = (Cards[randomIndex], Cards[i]);
		        }
	        }

	        public void Draw()
			{
				// todo: define deck drawing area (placement/size)

				foreach (Card card in Cards)
				{
					card.Draw();
				}
			}
        }

        private class Card
        {

	        public readonly CardType Type;
	        public readonly int Number;

	        public Card(int number, CardType type)
	        {
		        Number = number;
		        Type = type;
	        }

	        public string NumberName()
	        {
		        return Number switch
		        {
			        1 => "Ace",
			        11 => "Jack",
			        12 => "Queen",
			        13 => "King",
			        _ => Number.ToString(),
		        };
	        }

	        public string FullName()
	        {
		        return $"{NumberName()} of {Type}";
	        }

	        public void Draw()
			{
				Rectangle rect = new Rectangle(); // todo: define card placement/size
				 _graphics.DrawRectangle(_cardPen, rect);

				 // todo: draw card number/name
			}
        }
    }
}