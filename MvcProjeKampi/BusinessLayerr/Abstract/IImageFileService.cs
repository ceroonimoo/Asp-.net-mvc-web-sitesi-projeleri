using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayerr.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();
    }
}
