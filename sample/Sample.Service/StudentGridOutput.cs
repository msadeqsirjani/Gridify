using Gridify;
using Gridify.Filter;
using Gridify.Meta;
using Gridify.Order;
using Sample.Entity;

namespace Sample.Repository
{
    public class StudentGridResponse : GridResponse<Student>
    {
        public override void InitSchema()
        {
            Meta(x => x.Id)
                .IsKey()
                .IsVisible(false);

            Meta(x => x.Name)
                .AddTitle("عنوان")
                .AddFilter(new Filter
                {
                    Key = nameof(Student) + "." + nameof(Student.Name),
                    Operator = Operators.Contains,
                    DataType = DataType.String,
                    Value = null
                })
                .AddOrder(new Order
                {
                    OrderBy = nameof(Student.Name),
                    Direction = OrderDirection.Asc
                })
                .AddOrder(new Order
                {
                    OrderBy = nameof(Student.Name),
                    Direction = OrderDirection.Desc
                });

            Meta(x => x.Birthday)
                .AddTitle("تاریخ تولد");
        }
    }
}
