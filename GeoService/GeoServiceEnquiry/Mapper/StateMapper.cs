using GeoServiceEnquiry.Model;
using GeoServiceProvider.Controller;
using GeoServiceProvider.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoServiceEnquiry.Mapper
{
    public class StateMapper
    {
        private static readonly StateMapper _instance = new StateMapper();

        public static StateMapper Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<State> mapRetrieveStateList()
        {
            List<State> states = new List<State>();

            StateController.Instance.retrieveStateList().ForEach(delegate(StateDTO stateItem)
            {
                states.Add(new State
                {
                    StateId = stateItem.StateId,
                    StateName = stateItem.StateName,
                    StateCode = stateItem.StateCode,
                    Valid = true
                });
            });

            return states;
        }

        public List<State> mapRetrieveStateListByCountryCode(string countryCode)
        {
            List<State> states = new List<State>();

            StateController.Instance.retrieveStateListByCountryCode(countryCode).ForEach(delegate(StateDTO stateItem)
            {
                states.Add(new State
                {
                    StateId = stateItem.StateId,
                    StateName = stateItem.StateName,
                    StateCode = stateItem.StateCode,
                    Valid = true
                });
            });

            return states;
        }

        public State mapRetrieveStateByStateCode(string stateCode)
        {
            var state = StateController.Instance.retrieveStateByStateCode(stateCode);
            if (state != null)
            {
                return new State 
                {
                    StateId = state.StateId,
                    StateName = state.StateName,
                    StateCode = state.StateCode,
                    Valid = true
                };
            }

            return new State();
        }
    }
}