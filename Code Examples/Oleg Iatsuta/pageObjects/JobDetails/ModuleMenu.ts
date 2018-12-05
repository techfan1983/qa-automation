import {JobDetailsPage} from "./JobDetailsPage";

export class ModuleMenu {
    private Parent: JobDetailsPage;

    constructor(parent: JobDetailsPage) {
        this.Parent = parent;
    }

    baseElement = () => this.Parent.baseElement().find(".jms-module-menu");

    productionWorkflowsButton = () => this.baseElement().contains("P");
    ordersButton = () => this.baseElement().contains("O");
    manageButton = () => this.baseElement().contains("M");
    jobGeneralButton = () => this.baseElement().contains("J");

    ensureIsOnOrdersButton = () => this.ordersButton().then(($o) => {
        if ($o.parent().hasClass("off")) $o.click()
    });
}