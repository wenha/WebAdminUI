using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core
{
    /// <summary>
    /// 实体标记接口
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public interface IEntity<Tkey>
    {
        Tkey Id { get; set; }
    }
}
