using System;
using System.Collections.Generic;
using BoxDb.Contract;

namespace BoxDb.Domain
{
    public class BoxDbImplementation : IBoxDb
    {
        private Dictionary<string, string> _state = new Dictionary<string, string>();

        private Stack<List<IOperation>> _pendingTransactions = new Stack<List<IOperation>>(); // rollback
        private bool TrabsactionOpened => _pendingTransactions.Count != 0;
        
        public string Handle(string input)
        {
            var args = input.Split(' ');
            var operation = args[0];

            switch (operation.ToUpper())
            {
                case "GET":
                    var result = Get(args[1]);
                    return string.IsNullOrEmpty(result) ? "NULL" : result;
                case "SET":
                    Set(args[1], args[2]);
                    return string.Empty;
                case "DELETE":
                    Delete(args[1]);
                    return string.Empty;
                case "COUNT":
                    return Count(args[1]).ToString();
                case "BEGIN":
                    Begin();
                    return string.Empty;
                case "ROLLBACK":
                    Rollback();
                    return string.Empty;
                case "COMMIT":
                    Commit();
                    return string.Empty;
                default:
                    throw new InvalidOperationException("Operation not supported.");
            }
        }

        public void Set(string key, string value)
        {
            if (TrabsactionOpened)
            {
                 var collection = _pendingTransactions.Peek();
            }
            else
            {
                if (_state.ContainsKey(key))
                {
                    _state[key] = value;
                }
                else
                {
                    _state.Add(key, value);
                }
            }
        }

        public string Get(string key)
        {
            if (TrabsactionOpened)
            {
                throw new NotImplementedException();
            }
            else
            {
                if (_state.ContainsKey(key))
                {
                    return _state[key];
                }

                return null;
            }
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public int Count(string value)
        {
            throw new NotImplementedException();
        }

        public void Begin()
        {
            TrabsactionOpened = true;
            throw new NotImplementedException();
        }

        public void Commit()
        {
            while (_pendingTransactions.Count != 0)
            {
                var opToPerform = _pendingTransactions.Pop();
                foreach (var op in opToPerform)
                {
                    op.
                }
            }
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }
    }
}
