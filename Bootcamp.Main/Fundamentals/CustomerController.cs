namespace BootcampDemo.Examples
{
    public class CustomerController
    {
        public ActionResult GetCustomer(int id)
        {
            if (id == 0)
                return new NotFound();

            return new Ok();
        }
    }

    public partial class ActionResult { }

    public class NotFound : ActionResult { }

    public class Ok : ActionResult { }
}