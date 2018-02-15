using System;
using Inedo.BuildMaster.Extensibility.IssueTrackerConnections;
using Inedo.Documentation;
using Inedo.Serialization;
using Inedo.Web;

namespace Inedo.BuildMasterExtensions.Jira
{
    [Serializable]
    [CustomEditor(typeof(JiraApplicationFilterEditor))]
    public sealed class JiraApplicationFilter : IssueTrackerApplicationConfigurationBase
    {
        [Persistent]
        public string ProjectId { get; set; }

        public override RichDescription GetDescription() => new RichDescription("Project ID: ", this.ProjectId);
    }
}
