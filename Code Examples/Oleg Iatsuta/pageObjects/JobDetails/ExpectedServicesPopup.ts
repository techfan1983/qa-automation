export class ExpectedServicesPopup {
    baseElement = () => cy.get("#modal-dialog .jobdetail-expectedservices-view");

    reportingService = () => this.baseElement().find(".service-buttons .service-row .vendor-services.reporter.checkbox:not(.tbd)");
    ensureReportingServiceChecked = () => this.reportingService().should("have.class", "checked");
    videographerService = () => this.baseElement().find(".service-buttons .vendor-services.videographer.checkbox:not(.tbd)");
    interpreter = () => this.baseElement().find(".service-buttons .vendor-services.interpreter.checkbox:not(.tbd)");
    updateButton = () => this.baseElement().find("button").contains("Update");
}