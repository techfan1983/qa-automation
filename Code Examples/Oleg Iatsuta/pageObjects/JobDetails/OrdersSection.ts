import {JobOrdersModule} from "./JobOrdersModule";

export class OrdersSection {
    private Parent: JobOrdersModule;

    constructor(parent: JobOrdersModule) {
        this.Parent = parent;
    }

    baseElement = () => this.Parent.baseElement().find(".module .header .title").contains("Orders").parent().parent();

    addOrderButton = () => this.baseElement().find("button").contains("Add Order");
}