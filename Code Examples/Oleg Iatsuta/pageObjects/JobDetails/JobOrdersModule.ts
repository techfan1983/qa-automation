import {JobDetailsPage} from "./JobDetailsPage";

export class JobOrdersModule {
    private Parent: JobDetailsPage;

    constructor(parent: JobDetailsPage) {
        this.Parent = parent;
    }

    baseElement = () => this.Parent.baseElement().find(".jobdetail-container");
}