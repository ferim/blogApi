using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IArticleRepository Article { get; }
        ICategoryRepository Category { get; }
        IArticleCategoryRepository ArticleCategory { get; }
        Task SaveAsync();
        void ClearTrackingData();
        void DetachedEntity(object entity);
    }
}
