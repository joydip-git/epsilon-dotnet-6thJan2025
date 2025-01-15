namespace CalculationLibrary
{
    public class Calculation
    {
        public static int Divide(int firstNum, int secondNum)
        {
            //try
            //{
            //    return firstNum / secondNum;
            //}
            //catch
            //{
            //    //re-throwing the same exception without catching it explicitly [just bypassing] using catch(Exception ex). this does not change the stack trace information that the exception was thrown from line : 14 actually
            //    throw;
            //}
            //catch (Exception ex) 
            //{
            //since you are rethrowing caught exception this will change the stakc trace information and will show line no: 18 as the line from where exception was thrown, whereas originally the exception was thrown from line no: 14
            //    throw ex;
            //}


            //if (secondNum == 0)
            //{
            //    ArgumentException ex = new("second number should not be zero.");
            //    throw ex;
            //}
            //else
            //    return firstNum / secondNum;

            if (secondNum == 0)
            {
                //DivisionArgumentException ex = new("second argument in the divide method should not be zero.");
                DivisionArgumentException ex = new();
                throw ex;
            }
            else
                return firstNum / secondNum;
        }

    }
}
