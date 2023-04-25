import { Pipe, PipeTransform } from '@angular/core';
import { DatePipe } from '@angular/common';

@Pipe({name: 'dateFormat'})
export class DateFormatPipe implements PipeTransform {

  transform(value: string | null): string|null {
    if (!value) {
      return '';
    }
    const date = new Date(value);
    const datePipe = new DatePipe('en-US');
    let stri= datePipe.transform(date, 'yyyy-MM-dd HH:mm')
    return stri;
  }

}