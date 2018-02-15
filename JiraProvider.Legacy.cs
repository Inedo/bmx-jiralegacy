﻿using System.Linq;
using Inedo.BuildMaster.Extensibility.Providers.IssueTracking;

namespace Inedo.BuildMasterExtensions.Jira
{
    partial class JiraProvider : ICategoryFilterable
    {
        internal JiraApplicationFilter legacyFilter;

        string[] ICategoryFilterable.CategoryIdFilter
        {
            get
            {
                if (this.legacyFilter != null)
                    return new[] { this.legacyFilter.ProjectId };
                else
                    return null;
            }
            set
            {
                if (value != null && value.Length > 0)
                    this.legacyFilter = new JiraApplicationFilter { ProjectId = value[0] };
                else
                    this.legacyFilter = null;
            }
        }
        string[] ICategoryFilterable.CategoryTypeNames => new[] { "Project" };

        IssueTrackerCategory[] ICategoryFilterable.GetCategories()
        {
            return (from p in this.Client.GetProjects()
                    select JiraCategory.CreateProject(p)).ToArray();
        }
    }
}
