import { AssessmentYuriPereiraJSPage } from './app.po';

describe('assessment-yuri-pereira-js App', () => {
  let page: AssessmentYuriPereiraJSPage;

  beforeEach(() => {
    page = new AssessmentYuriPereiraJSPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
