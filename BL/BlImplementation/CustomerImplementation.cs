
using static BO.Tools;
namespace BlImplementation;

internal class CustomerImplementation : BlApi.ICustomer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Customer item)
    {
        try
        {
            if (item == null)
            {
                throw new ArgumentNullException("לא נשלח לקוח לעדכון");
            }
            DO.Customer customer = item.CastCustomerBOToDO();
            var c = _dal.Customer.Read(item.Id);
            if(c!=null)
            {
                throw new BO.BlIdExistExeption("נמצא כבר לקוח עם תעודת זהות זו");
            }
            return _dal.Customer.Create(customer);
        }
        catch (DO.DalIdExistExeption e)
        {
            throw new BO.BlIdExistExeption("", e);
        }
    }


    public BO.Customer? Read(int id)
    {
        try
        {
            DO.Customer customerDO = _dal.Customer.Read(id);
            if (customerDO == null)
            {
                throw new BO.BlNullObjectExeption("לא נמצא לקוח עם קוד זה");
            }
            
            return customerDO.CastCustomerDOToBO();
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }

    public BO.Customer? Read(Func<BO.Customer, bool> filter)
    {
        try
        {
            if (filter == null)
                throw new BO.BlNullObjectExeption("לא נשלח פרמטר לסינון");

            List<DO.Customer?> list = _dal.Customer.ReadAll();

            DO.Customer? customer = list.SingleOrDefault<DO.Customer?>(p => filter(p.CastCustomerDOToBO()));
            if (customer == null)
                throw new BO.BlNullObjectExeption("לא נמצא לקוח עם סינון זה");
            return customer?.CastCustomerDOToBO();

        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }

    public List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter = null)
    {
        try
        {
            List<DO.Customer?> listDO = _dal.Customer.ReadAll();

            List<BO.Customer?> listBO;

            if (filter == null)
            {
                listBO = (from c in listDO
                          select c.CastCustomerDOToBO()).ToList();
            }
            else
            {
                listBO = (from c in listDO
                          let bo = c.CastCustomerDOToBO()
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

    public void Update(BO.Customer item)
    {
        try
        {
            if (item == null)
            {
                throw new ArgumentNullException("לא נשלח לקוח לעדכון");
            }
            int id = item.Id;

            var c = _dal.Customer.Read(id);

            if (c == null)
            {
                throw new BO.BlIdNotExistExeption("לא ניתן למחוק לקוח לא קיים.");
            }

            _dal.Customer.Update(item.CastCustomerBOToDO());
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }


    public void Delete(int id)
    {
        try
        {
            var c = _dal.Customer.Read(id);
            if (c == null)
            {
                throw new BO.BlIdNotExistExeption("אי אפשר למחוק לקוח לא קיים.");
            }
            _dal.Customer.Delete(id);
        }
        catch (DO.DalIdNotExistExeption e)
        {
            throw new BO.BlIdNotExistExeption("", e);
        }
    }
    public bool IsExist(int id)
    {
        DO.Customer? customerDO = _dal.Customer.Read(id);
        return customerDO != null;
    }
}
