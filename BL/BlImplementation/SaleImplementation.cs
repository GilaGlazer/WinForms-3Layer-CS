


using static BO.Tools;

namespace BlImplementation;

internal class SaleImplementation:BlApi.ISale
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Sale item)
    {
        try
        {
            if(item == null)
            {
                throw new ArgumentNullException("לא נשלח מבצע להוספה");
            }
            int idSaleP = item.IdSaleP;

            // בדיקה אם המוצר קיים
            var product = _dal.Product.Read(idSaleP);
            if (product == null)
            {
                throw new BO.BlIdNotExistExeption("אי אפשר להוסיף מבצע למוצר לא קיים.");
            }

            DO.Sale sale = item.CastSaleBOtoDO();
            return _dal.Sale.Create(sale);
        }
        catch (DO.DalIdExistExeption e)
        {
            throw new BO.BlIdExistExeption("", e);
        }
    }

    public void Delete(int id)
    {
        try
        {
            var sale = _dal.Sale.Read(id);
            if (sale == null)
            {
                throw new BO.BlIdNotExistExeption("אי אפשר למחוק מבצע לא קיים.");
            }

            _dal.Sale.Delete(id);
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }

    public BO.Sale? Read(int id)
    {
        try
        {
            DO.Sale sale = _dal.Sale.Read(id);
            if (sale == null)
            {
                throw new BO.BlNullObjectExeption("לא נמצא מבצע עם קוד זה");
            }

            return sale.CastSaleDOToBO();
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }

    public BO.Sale? Read(Func<BO.Sale, bool> filter)
    {
        try
        {
            if (filter == null)
                throw new BO.BlNullObjectExeption("לא נשלח פרמטר לסינון");

            List<DO.Sale?> list = _dal.Sale.ReadAll();

            DO.Sale? sale = list.SingleOrDefault<DO.Sale?>(p => filter(p.CastSaleDOToBO()));

            if (sale == null)
                throw new BO.BlNullObjectExeption("לא נמצא מבצע עם סינון זה");

            return sale.CastSaleDOToBO();


        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }


    public List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter = null)
    {
        try
        {
            List<DO.Sale?> listDO = _dal.Sale.ReadAll();
            List<BO.Sale?> listBO;

            if (filter == null)
            {
                listBO = (from c in listDO
                          select c.CastSaleDOToBO()).ToList();
            }
            else
            {
                listBO = (from c in listDO
                          let bo = c.CastSaleDOToBO()
                          where filter(bo)
                          select bo).ToList();
            }

            return listBO;
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }

    public void Update(BO.Sale item)
    {
        try
        {
            if (item == null)
            {
                throw new ArgumentNullException("לא נשלח מבצע לעדכון");
            }
            int id = item.IdSale;

            var sale = _dal.Sale.Read(id);

            if (sale == null)
            {
                throw new BO.BlIdNotExistExeption("אי אפשר לעדכן מבצע לא קיים.");
            }

            //בדיקה שקוד מוצר תקין
            var p = _dal.Product.Read(item.IdSaleP);
            if (p == null)
            {
                throw new BO.BlIdNotExistExeption("אי אפשר לעדכן מבצע למוצר לא קיים.");
            }


            _dal.Sale.Update(item.CastSaleBOtoDO());
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }
}
