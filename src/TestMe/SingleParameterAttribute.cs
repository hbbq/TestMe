namespace TestMe
{

    public class SingleParameterAttribute : TestAttributeBase
    {

        public SingleParameterAttribute(object parameter, object expectedValue) : base(expectedValue, new[] { parameter })
        {
        }

    }

}
