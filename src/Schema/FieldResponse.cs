using Fop.Meta;
using System.Collections.Generic;

namespace Fop.Schema
{
    public class FieldResponse
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public bool IsKey { get; set; }
        public bool IsVisible { get; set; }
        public bool IsVisibleDefault { get; set; }
        public bool IsEditable { get; set; }
        public bool IsSelectable { get; set; }
        public bool IsDetail { get; set; }
        public int Order { get; set; }

        public FieldResponse FillFieldResponse(List<IMeta> metas)
        {
            if (metas == null)
                return this;

            metas.ForEach(meta =>
            {
                switch (meta.GetType().Name)
                {
                    case nameof(MetaName):
                        Name = ((MetaName)meta).Name;
                        break;
                    case nameof(MetaTitle):
                        Title = ((MetaTitle)meta).Title;
                        break;
                    case nameof(MetaKey):
                        IsKey = true;
                        break;
                    case nameof(MetaVisible):
                        IsVisible = ((MetaVisible)meta).IsVisible;
                        if (!IsVisible)
                            IsVisibleDefault = false;
                        break;
                    case nameof(MetaVisibleDefault):
                        IsVisibleDefault = ((MetaVisibleDefault)meta).IsVisibleDefault;
                        break;
                    case nameof(MetaSelectable):
                        IsSelectable = ((MetaSelectable)meta).IsSelectable;
                        break;
                    case nameof(MetaEditable):
                        IsEditable = ((MetaEditable)meta).IsEditable;
                        break;
                    case nameof(MetaDetail):
                        IsDetail = ((MetaDetail)meta).IsDetail;
                        break;
                    case nameof(MetaOrder):
                        Order = ((MetaOrder)meta).Order;
                        break;
                }
            });

            return this;
        }
    }
}