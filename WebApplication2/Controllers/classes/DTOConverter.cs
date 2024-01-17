namespace WebApplication2.Controllers.classes
{
    public class DTOConverter
    {
        public twoDTO converter(Object obj)
        {
            var p3 = obj.GetType().GetProperty("p3");
            var v = new twoDTO
            {
                p1 = (int)obj.GetType().GetProperty("p1").GetValue(obj, null),
                p2 = (int)obj.GetType().GetProperty("p2").GetValue(obj, null),
                p3 = p3 != null ? (int)p3.GetValue(obj, null) : null,
            };
            return v;
        }
    }
}
