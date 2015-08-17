﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DynamicReport.Report;
using SchoolReport.Models.SchoolReportsMapping;

namespace SchoolReport.Models
{
    public class ReportsModel
    {
        private readonly DbContext _context;
        private readonly ReportType _reportType;

        private IReportModel Report
        {
            get
            {
                IReportModel results;

                switch (_reportType)
                {
                    case ReportType.StudentReport:
                        results = new StudentsReport(_context).CreateReport();
                        break;
                    default:
                        throw new NotImplementedException(string.Format("GetReportModel not implemented for type: {0}", _reportType));
                }

                return results;
            }
        }

        public ReportsModel(ReportType reportType, DbContext context)
        {
            _reportType = reportType;
            _context = context;
        }

        /// <summary>
        /// Get All possible repor types.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ReportTypeDTO> GetReportTypes()
        {
            return new[]
            {
                new ReportTypeDTO {Type = ReportType.StudentReport.ToString()}
            };
        }
        
        /// <summary>
        /// Get All possible filter types.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ReportFilterDTO> GetReportFilterOperators()
        {
       
            return new[]
            {
                new ReportFilterDTO {FilterTitle = "Is equal to", FilterType = (int)FilterType.Equal},
                new ReportFilterDTO {FilterTitle = "Is not equal to", FilterType = (int)FilterType.NotEqual},
                new ReportFilterDTO {FilterTitle = "Is greater than or equal to", FilterType = (int)FilterType.GreatThenOrEqualTo},
                new ReportFilterDTO {FilterTitle = "Is greater than", FilterType = (int)FilterType.GreatThen},
                new ReportFilterDTO {FilterTitle = "Is less than or equal to", FilterType = (int)FilterType.LessThenOrEquaslTo},
                new ReportFilterDTO {FilterTitle = "Is less than", FilterType = (int)FilterType.LessThen},
                new ReportFilterDTO {FilterTitle = "Includes", FilterType = (int)FilterType.Include},
                new ReportFilterDTO {FilterTitle = "Not includes", FilterType = (int)FilterType.NotInclude},
            };
        }

        /// <summary>
        /// Get All possible report columns.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ReportColumnDTO> GetReportColumns()
        {
            return Report.ReportFields.Select(x => new ReportColumnDTO { Title = x.Title, Alias = x.SqlAlias });
        }

        public List<Dictionary<string, object>> GetReportData(ReportDTO reportDto)
        {
            var fields = reportDto.Columns.Select(title => Report.GetReportField(title));
            var filters = reportDto.Filters.Select(filter => new ReportFilter
            {
                ReportField = Report.GetReportField(filter.ReportFieldTitle),
                Type = (FilterType)filter.FilterType,
                Value = filter.FilterValue
            });

            return Report.Get(fields, filters);
        }
    }

    public enum ReportType
    {
        StudentReport
    }
}