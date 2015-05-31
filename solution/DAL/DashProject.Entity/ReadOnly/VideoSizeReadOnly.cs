using System;
using Manitou.Entity.Base;
using Manitou.Data.Item.Base;

namespace DashProject.Entity.ReadOnly
{
    public sealed class VideoSizeReadOnly : VideoSizeReadOnlyBase
    {
        public VideoSizeReadOnly()
            : base()
        {
        }

        public VideoSizeReadOnly(DashProject.Data.Item.VideoSize item)
            : base(item)
        {
        }
    }
}