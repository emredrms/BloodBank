
using GeoServiceData;
using GeoServiceProvider.Model;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoServiceProvider.Helper;

namespace GeoServiceProvider.Controller
{
    public class StateController
    {
        private static readonly StateController _instance = new StateController();

        public static StateController Instance
        {
            get
            {
                return _instance;
            }
        }

        public List<StateDTO> retrieveStateList()
        {
            List<StateDTO> states = new List<StateDTO>();

            try
            {
                List<State> stateList = Repository.dbConnection.State.Where(s => s.Valid).ToList();

                if (stateList != null)
                {
                    stateList.ForEach(delegate(State stateItem)
                    {
                        states.Add(new StateDTO
                        {
                            StateId = stateItem.StateId,
                            StateName = stateItem.StateName.Trim(),
                            StateCode = stateItem.StateCode.Trim()
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }

            return states;
        }

        public List<StateDTO> retrieveStateListByCountryCode(string countryCode)
        {
            List<StateDTO> states = new List<StateDTO>();

            try
            {
                List<State> stateList = Repository.dbConnection.State.Where(s => s.Valid && s.CountryCode == countryCode).ToList();

                if (stateList != null)
                {
                    stateList.Where(s => s.Valid && s.CountryCode == countryCode).ToList().ForEach(delegate(State stateItem)
                    {
                        states.Add(new StateDTO
                        {
                            StateId = stateItem.StateId,
                            StateName = stateItem.StateName.Trim(),
                            StateCode = stateItem.StateCode.Trim()
                        });
                    });
                }
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }

            return states;
        }

        public StateDTO retrieveStateByStateCode(string stateCode)
        {
            try
            {
                var state = Repository.dbConnection.State.Where(s => s.Valid && s.StateCode == stateCode).FirstOrDefault();

                if (state == null)
                    return null;

                return new StateDTO
                {
                    StateId = state.StateId,
                    StateName = state.StateName.Trim(),
                    StateCode = state.StateCode.Trim()
                };
            }
            catch (Exception ex)
            {
                ex.toExceptionLog(GeoServiceConstant.Exception_File_Path);
            }

            return new StateDTO();

        }
    }
}
