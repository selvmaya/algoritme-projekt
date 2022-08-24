namespace Algoritmer
{
    public partial class GameForm : Form
    {
	    private const int CardCount = 13;
	    private const int DeckSize = 52;

	    private static readonly Random Random = new Random();

	    private readonly Deck _mainDeck;
	    private Graphics _graphics;
	    private Pen cardPen;

	    public GameForm() // effectively start
        {
	        InitializeComponent();

	        _graphics = CreateGraphics();
	        cardPen = new Pen(Color.Red, 5);

	        _mainDeck = new Deck();
	        _mainDeck.Shuffle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
			BackColor = Color.Black;

			DrawDeck();
        }

        private void DrawDeck()
        {
	        // todo: define deck drawing area (placement/size)

	        foreach (Card card in _mainDeck.Cards)
	        {
		        DrawCard(card);
	        }
        }

        private void DrawCard(Card card)
        {
	        Rectangle rect = new Rectangle(); // todo: define card placement/size
			_graphics.DrawRectangle(cardPen, rect);

			// todo: draw card number/name
        }

        private class Deck
        {
	        public readonly List<Card> Cards;

	        public Deck() // fresh deck
	        {
		        Cards = new List<Card>();
		        const int amountOfCardsPerType = DeckSize / CardCount;
		        for (int cardTypeIndex = 0; cardTypeIndex < CardCount; cardTypeIndex++)
		        {
			        for (int type = 0; type < amountOfCardsPerType; type++)
			        {
				        Cards.Add(new Card(cardTypeIndex));
			        }
		        }
	        }

	        public Deck(List<Card> cards)
	        {
		        Cards = cards;
	        }

	        public void Shuffle()
	        {
		        for (int i = 0; i < DeckSize; i++)
		        {
			        int randomIndex = Random.Next(DeckSize);
			        // swap cards
			        (Cards[i], Cards[randomIndex]) = (Cards[randomIndex], Cards[i]);
		        }
	        }
        }

        private class Card
        {
	        public readonly int Value;

	        public Card(int value)
	        {
		        Value = value;
	        }

	        public string Name()
	        {
		        return Value switch
		        {
			        11 => "Jack",
			        12 => "Queen",
			        13 => "King",
			        _ => Value.ToString(),
		        };
	        }

        }
    }
}