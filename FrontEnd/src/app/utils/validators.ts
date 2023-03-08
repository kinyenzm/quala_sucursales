import { AbstractControl, ValidationErrors, ValidatorFn } from "@angular/forms";

export function minDateValidator(minDate: Date): ValidatorFn {
	return (control: AbstractControl): ValidationErrors | null => {
		const controlValue = new Date(control.value);
		if (controlValue < minDate) {
			return { minDate: true };
		}
		return null;
	};
}
