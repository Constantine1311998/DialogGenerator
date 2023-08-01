using System.ComponentModel;

namespace DialogGenerator.Enums
{
    /// <summary>
    /// Information Box Button Enum handles what kind of buttons
    /// should be populated while creating the information box.
    /// </summary>
    public enum InformationBoxButton
    {
        /// <summary>
        /// Generates single OK Button
        /// </summary>
        OK,

        /// <summary>
        /// Generates OK and Cancel Button
        /// </summary>
        OkCancel,

        /// <summary>
        /// Generates Yes and No Button
        /// </summary>
        YesNo,

        /// <summary>
        /// Generates Yes , No and Cancel button
        /// </summary>
        YesNoCancel
    }

    /// <summary>
    /// Provides the selection of Images that can be shown in Information box
    /// </summary>
    public enum InformationBoxImage
    {
        /// <summary>
        /// No Images are displayed.
        /// Description will be empty
        /// </summary>
        [Description("")]
        None,

        /// <summary>
        /// Error Image displayed
        /// Description Error
        /// </summary>
        [Description("Error")]
        Error,

        /// <summary>
        /// Hand Image displayed
        /// Description Error
        /// </summary>
        [Description("Error")]
        Hand,

        /// <summary>
        /// Stop Image displayed
        /// Description Stop
        /// </summary>
        [Description("Stop")]
        Stop,

        /// <summary>
        /// Question Image Displayed
        /// Description Question
        /// </summary>
        [Description("Question")]
        Question,

        /// <summary>
        /// Exclamation Icon
        /// Description Warning
        /// </summary>
        [Description("Warning")]
        Exclamation,

        /// <summary>
        /// Warning Icon
        /// Description Warning
        /// </summary>
        [Description("Warning")]
        Warning,

        /// <summary>
        /// Asterik Icon
        /// Description Asterik
        /// </summary>
        [Description("Warning")]
        Asterisk,

        /// <summary>
        /// Information Icon
        /// Description Information
        /// </summary>
        [Description("Information")]
        Information
    }

    /// <summary>
    /// Results from Information Box
    /// </summary>
    public enum InformationBoxResult
    {
        /// <summary>
        /// When No button clicked. Default result
        /// </summary>
        None = 0,

        /// <summary>
        /// OK Button Clicked
        /// </summary>
        OK = 1,

        /// <summary>
        /// Cancel Button Clicked
        /// </summary>
        Cancel = 2,

        /// <summary>
        /// Yes Button Clicked
        /// </summary>
        Yes = 6,

        /// <summary>
        /// No Button Clicked
        /// </summary>
        No = 7
    }
}