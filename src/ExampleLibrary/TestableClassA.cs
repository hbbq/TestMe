namespace ExampleLibrary
{

    public class TestableClassA
    {

        [TestMe.NoParameters(true)] //Sets up a test case that expects this method to return <true>
        public bool ReturnTrue() => true;

        [TestMe.NoParameters(false)] //Sets up a test case that expects this method to return <false>
        public bool ReturnFalse() => false;

        [TestMe.SingleParameter(1, 2)] //Sets up a test case that expects this method to return <2> for the parameter <1>
        [TestMe.SingleParameter(2, 4)] //Sets up a test case that expects this method to return <4> for the parameter <2>
        public int TimesTwo(int value) => value * 2;

    }

}
