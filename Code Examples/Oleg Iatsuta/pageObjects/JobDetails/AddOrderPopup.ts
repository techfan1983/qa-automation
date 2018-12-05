export class AddOrderPopup {
    baseElement = () => cy.get("#modal-dialog .modal-content .module .header:contains('Order Details')").parent().parent();

    jobFirmSelect = () => this.baseElement().contains(/Job Firm/).parent().find("select").first();
    selectFirstFirm = () => this.jobFirmSelect().within($select => {
        cy.wrap($select).select(<string>$select.find("option:eq(1)").val());
    });

    updateButton = () => this.baseElement().contains("Order Details").parent().parent().find("button").contains("Update").first();
}