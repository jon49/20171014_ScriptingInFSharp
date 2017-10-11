module IfInteractive

#if INTERACTIVE
let msg = "Started in Interactive mode."
#else
let msg = "Started with the command line."
#endif
