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
	    private const int HighestCardNumber = 13;
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

			_mainDeck.Draw(_graphics, _cardPen);
        }


        private class Deck
        {
	        public readonly List<Card> Cards;

	        public Deck() // fresh deck of cards
	        {
		        Cards = FreshCards();
	        }

	        private List<Card> FreshCards()
	        {
		        List<Card> cards = new List<Card>();
		        for (int numberIndex = 0; numberIndex < HighestCardNumber; numberIndex++)
		        {
			        Array types = Enum.GetValues(typeof(CardType));
			        int typeTotal = types.Length;
			        for (int typeIndex = 0; typeIndex < typeTotal; typeIndex++)
			        {
				        CardType type = (CardType)types.GetValue(typeIndex)!;
				        Card card = new Card(numberIndex, type);
						cards.Add(card);
			        }
		        }
		        return cards;
	        }

	        public void Shuffle()
	        {
		        for (int i = 0; i < DeckSize; i++)
		        {
			        int randomIndex = Random.Next(DeckSize);
			        // swap card index with random card index
			        (Cards[i], Cards[randomIndex]) = (Cards[randomIndex], Cards[i]);
		        }
	        }

	        public void Draw(Graphics graphics, Pen pen)
			{
				// todo: define deck drawing area (placement/size)

				foreach (Card card in Cards)
				{
					card.Draw(graphics, pen);
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

	        public void Draw(Graphics graphics, Pen pen)
			{
				Rectangle rect = new Rectangle(); // todo: define card placement/size
				 graphics.DrawRectangle(pen, rect);

				 // todo: draw card number/name
			}
        }
    }
}