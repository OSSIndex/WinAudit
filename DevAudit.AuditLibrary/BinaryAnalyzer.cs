﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Alpheus;

namespace DevAudit.AuditLibrary
{
    #region Public types
    public struct BinaryAnalyzerResult
    {
        public BinaryAnalyzer Analyzer;
        public bool Succeded;
        public bool IsVulnerable;
        public List<Exception> Exceptions;
        public List<string> DiagnosticMessages;
    }
    #endregion

    public abstract class BinaryAnalyzer
    {
        #region Constructors
        public BinaryAnalyzer(ScriptEnvironment script_env, string name, object modules, IConfiguration configuration, Dictionary<string, object> application_options)
        {
            this.ScriptEnvironment = script_env;
            this.Name = name;
            this.AnalyzerResult = new BinaryAnalyzerResult() { Analyzer = this };
            this._Modules = modules;
            this.Configuration = configuration;
            this.ApplicationOptions = application_options;
        }
        #endregion

        #region Public properties
        public string Name { get; protected set; }
        public string Summary { get; protected set; }
        public string Description { get; protected set; }
        public List<string> Tags { get; protected set; } = new List<string>(3);
        public BinaryAnalyzerResult AnalyzerResult { get; protected set; }
        protected ScriptEnvironment ScriptEnvironment { get; set; }
        protected object _Modules { get; set; }
        protected IConfiguration Configuration { get; set; }
        protected Dictionary<string, object> ApplicationOptions { get; set; }
        #endregion

        #region Public abstract methods
        public abstract Task<BinaryAnalyzerResult> Analyze();
        #endregion
    }
}