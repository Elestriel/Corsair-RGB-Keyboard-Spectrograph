public class RaiseEventUtility
{
    public static void RaiseEventAndExecuteItInTheTargetThread(System.MulticastDelegate _event, object[] _ParamArray_args)
    {
        if ((_event != null))
        {
            if (_event.GetInvocationList().Length > 0)
            {
                System.ComponentModel.ISynchronizeInvoke _sync = null;
                foreach (System.MulticastDelegate _delegate in _event.GetInvocationList())
                {
                    if (((_sync == null) && (typeof(System.ComponentModel.ISynchronizeInvoke).IsAssignableFrom(_delegate.Target.GetType())) && (!_delegate.Target.GetType().IsAbstract)))
                    {
                        try
                        {
                            _sync = (System.ComponentModel.ISynchronizeInvoke)_delegate.Target;
                        }
                        catch (System.Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.ToString());
                            _sync = null;
                        }
                    }
                    if (_sync == null)
                    {
                        try
                        {
                            _delegate.DynamicInvoke(_ParamArray_args);
                        }
                        catch (System.Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.ToString());
                        }
                    }
                    else
                    {
                        try
                        {
                            _sync.Invoke(_delegate, _ParamArray_args);
                        }
                        catch (System.Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine(ex.ToString());
                        }
                    }
                }
            }
        }
    }
}
