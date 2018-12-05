import {ExpectedServicesPopup} from "./ExpectedServicesPopup";

export class InterpreterSection {
    private Parent: ExpectedServicesPopup;

    constructor(parent: ExpectedServicesPopup) {
        this.Parent = parent;
    }

    baseElement = () => this.Parent.baseElement().find(".module .header .title:contains('Interpreter')").parent().parent();

    tsgSuppliesRadioButton = () => this.baseElement().find(".content:not(.masked) label.radio:contains('TSG Supplies')");
}