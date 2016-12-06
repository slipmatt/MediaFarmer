using MediaFarmer.Context.Extensions;
using MediaFarmer.ViewModels;
using UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MusicFarmer.Data;

namespace MediaFarmer.Context.Repositories
{
    public class RepositorySettings
    {
        private static IUow _uow;
        private static IRepository<SettingValue> repo;
        public RepositorySettings(IUow uow)
        {
            _uow = uow;
            repo = _uow.GetRepo<SettingValue>();
        }
        public List<SettingValueViewModel> GetAllSettings()
        {
            return repo.GetByQuery(i=>i.SettingName!="").Select(i => i.ToModel()).ToList();
        }

        public List<SettingValueViewModel> GetFilteredSettingsByName(string filter)
        {
            return repo.GetByQuery(i => i.SettingName.Contains(filter)).Select(i => i.ToModel()).ToList();
        }

        public SettingValueViewModel GetFilteredSettingsById(int filter)
        {
            return repo.GetByQuery(i => i.SettingValueId.Equals(filter)).Select(i => i.ToModel()).FirstOrDefault();
        }

        public void AddSetting(SettingValueViewModel SettingValue)
        {
            repo.Add(SettingValue.ToData());
            repo.SaveChanges();
        }

        public void UpdateSetting(SettingValueViewModel SettingValue)
        {
            var setting = repo.GetByQuery(i => i.SettingValueId == SettingValue.SettingId).FirstOrDefault();

            repo.Update(setting.UpdateData(SettingValue));
            repo.SaveChanges();
        }
    }
}