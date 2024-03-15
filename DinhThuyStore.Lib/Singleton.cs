using DinhThuyStore.Lib.Interface;
using DinhThuyStore.Lib.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhThuyStore.Lib
{
    public class Singleton
    {
        public static AccountInterface accountInterface;
        public static CategoryInterface categoryInterface;
        public static ProductInterface productInterface;
        public static ImageInterface imageInterface;
        private static readonly object SyncLock = new object();

        public static AccountInterface AccountInterface
        {
            get
            {
                if(accountInterface == null)
                {
                    lock (SyncLock)
                    {
                        if (accountInterface == null)
                        {
                            accountInterface = new AccountService();
                        }
                    }
                }
                return accountInterface;
            }
        }

        public static CategoryInterface CategoryInterface
        {
            get
            {
                if (categoryInterface == null)
                {
                    lock (SyncLock)
                    {
                        if (categoryInterface == null)
                        {
                            categoryInterface = new CategoryService();
                        }
                    }
                }
                return categoryInterface;
            }
        }

        public static ProductInterface ProductInterface
        {
            get
            {
                if (productInterface == null)
                {
                    lock (SyncLock)
                    {
                        if (productInterface == null)
                        {
                            productInterface = new ProductService();
                        }
                    }
                }
                return productInterface;
            }
        }

        public static ImageInterface ImageInterface
        {
            get
            {
                if (imageInterface == null)
                {
                    lock (SyncLock)
                    {
                        if (imageInterface == null)
                        {
                            imageInterface = new ImageService();
                        }
                    }
                }
                return imageInterface;
            }
        }
    }
}
