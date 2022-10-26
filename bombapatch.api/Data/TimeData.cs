using bombapatch.api.Models;

namespace bombapatch.api.Data
{
    public class TimeData
    {
        List<Time> times = new List<Time>();
        
        public void AddTime(Time time)
        {
            times.Add(time);
        }

        public List<Time> BuscarTodosTimes() 
        {
            return times;
        }
    }
}