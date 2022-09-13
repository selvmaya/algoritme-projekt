namespace Algoritmer;

public partial class GameForm : Form
{
	private readonly Deck _mainDeck;
	private readonly Graphics _graphics;
	private readonly Pen _cardPen;

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
}