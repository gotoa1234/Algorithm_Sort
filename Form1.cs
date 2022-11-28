using Algorithm_Sort.NotPractical;
using Algorithm_Sort.Practical;

namespace Algorithm_Sort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var insertionExecute = new InsertionSortExecute();
            insertionExecute.Execute();

            var panCakeExecute = new PancakeSortExecute();
            panCakeExecute.Execute();

            var bogoExecute = new BogoSortExecute();
            bogoExecute.Execute();

            var gnomeSortExecute= new GnomeSortExecute();
            gnomeSortExecute.Execute();

            var stoogeExecute = new StoogeSortExecute();
            stoogeExecute.Execute();

            var bubbleExecute = new BubbleSortExecute();
            bubbleExecute.Execute();
        }
    }
}