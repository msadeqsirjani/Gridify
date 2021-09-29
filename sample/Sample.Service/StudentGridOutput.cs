using Gridify;
using Gridify.Meta;
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
                .AddTitle("عنوان");

            Meta(x => x.Birthday)
                .AddTitle("تاریخ تولد");
        }
    }
}
