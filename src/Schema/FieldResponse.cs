using System.Collections.Generic;
using Fop.Meta;

namespace Fop.Schema
{
    public class FieldResponse
    {
        public FieldResponse FillFieldResponse(List<IMeta> metas)
        {
            if (metas == null)
                return this;

            metas.ForEach(x =>
            {

            });
        }
    }
}